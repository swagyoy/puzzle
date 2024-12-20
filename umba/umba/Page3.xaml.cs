using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace umba
{
    public partial class Page3 : Page
    {
        private const int Rows = 5;
        private const int Columns = 5;
        private const int ImageSize = 80;

        private List<Image> pieces = new List<Image>();
        private Point offset;
        private Image draggingPiece;

        public Page3()
        {
            InitializeComponent();
            LoadPuzzle();
            back.IsEnabled = false;
        }

        private void LoadPuzzle()
        {
            var bitmap = new BitmapImage(new Uri("jojo2.jpg", UriKind.Relative)); ; 
            var originalPieces = new List<Image>();

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    var piece = new Image
                    {
                        Width = ImageSize,
                        Height = ImageSize,
                        Source = new CroppedBitmap(bitmap, new Int32Rect(col * ImageSize, row * ImageSize, ImageSize, ImageSize)),
                        Tag = $"{row},{col}" 
                    };

                    originalPieces.Add(piece);
                }
            }

            Random rand = new Random();
            foreach (var piece in originalPieces)
            {
                int randomIndex = rand.Next(pieces.Count + 1);
                pieces.Insert(randomIndex, piece);
            }

            for (int i = 0; i < pieces.Count; i++)
            {
                var piece = pieces[i];
                piece.MouseMove += Piece_MouseMove;
                piece.MouseLeftButtonDown += Piece_MouseLeftButtonDown;
                piece.MouseLeftButtonUp += Piece_MouseLeftButtonUp;

                Canvas.SetLeft(piece, rand.Next(0, 5) * ImageSize);
                Canvas.SetTop(piece, rand.Next(0, 5) * ImageSize);

                PuzzleCanvas.Children.Add(piece);
            }
        }

        private void Piece_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image piece)
            {
                draggingPiece = piece;
                offset = e.GetPosition(piece);
                Mouse.Capture(piece);
                piece.CaptureMouse();
            }
        }

        private void Piece_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggingPiece != null)
            {
                var position = e.GetPosition(PuzzleCanvas);
                Canvas.SetLeft(draggingPiece, position.X - offset.X);
                Canvas.SetTop(draggingPiece, position.Y - offset.Y);
            }
        }

        private void Piece_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (draggingPiece != null)
            {
                Mouse.Capture(null);
                draggingPiece.ReleaseMouseCapture();

                var position = e.GetPosition(PuzzleCanvas);
                int row = (int)(position.Y / ImageSize);
                int col = (int)(position.X / ImageSize);

                string correctPosition = $"{row},{col}";

                if (draggingPiece.Tag.ToString() == correctPosition)
                {
                    Canvas.SetLeft(draggingPiece, col * ImageSize);
                    Canvas.SetTop(draggingPiece, row * ImageSize);
                    draggingPiece.IsHitTestVisible = false; 
                }
                else
                {
                    ResetPiecePosition(draggingPiece);
                }

                draggingPiece = null;
                CheckPuzzleCompletion();
            }
        }

        private void ResetPiecePosition(Image piece)
        {
            var originalPosition = (string)piece.Tag;
            var positions = originalPosition.Split(',');
            int originalRow = int.Parse(positions[0]);
            int originalCol = int.Parse(positions[1]);

            Canvas.SetLeft(piece, originalCol * ImageSize);
            Canvas.SetTop(piece, originalRow * ImageSize);
        }

        private void CheckPuzzleCompletion()
        {
            foreach (var piece in pieces)
            {
                int row = (int)(Canvas.GetTop(piece) / ImageSize);
                int col = (int)(Canvas.GetLeft(piece) / ImageSize);
                string correctPosition = $"{row},{col}";

                if (piece.Tag.ToString() != correctPosition)
                {
                    return;
                }
            }
            back.IsEnabled = true;
            MessageBox.Show("пазл успешно собран!");
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page8());
        }
    }
}