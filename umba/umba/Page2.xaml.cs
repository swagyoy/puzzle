
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace umba
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void ButtPlay_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page6());
        }

        private void ButtExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
