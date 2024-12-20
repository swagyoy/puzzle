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
    public partial class Page8 : Page
    {
        public Page8()
        {
            InitializeComponent();
            labelwer.Content = "Weather Report \r\n(medium)";
            labelan.Content = "Narciso Anasui \r\n(hard)";
        }

        private void JojoAn_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void JojoWeth_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }

        private void BackofJojo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page6());
        }
    }
}
