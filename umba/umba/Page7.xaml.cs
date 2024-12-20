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
    public partial class Page7 : Page
    {
        public Page7()
        {
            InitializeComponent();
        }

        private void BackEva_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page6());
        }

        private void Eva01_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Page5());
        }

        private void Evang_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Page4());
        }
    }
}
