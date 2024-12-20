
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace umba
{
    public partial class Page6 : Page
    {
        public Page6()
        {
            InitializeComponent();
        }

        private void JojoColl_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Page8());
        }

        private void EvaColl_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Page7());
        }
    }
}
