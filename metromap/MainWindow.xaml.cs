using FirstFloor.ModernUI.Windows.Controls;
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

namespace MetroMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        FrameNavigationService nav;

        public MainWindow()
        {
            InitializeComponent();
            nav = FrameNavigationService.GetInstance();
            nav.Navigated += Nav_Navigated;
        }

        private void Nav_Navigated(object sender, EventArgs e)
        {
            if (nav.CurrentPage == "Home")
                buttonHome.Visibility = Visibility.Collapsed;
            else
                buttonHome.Visibility = Visibility.Visible;
        }

        private void ModernWindow_Loaded(object sender, RoutedEventArgs e)
        {
            nav.NavFrame = mainFrame;
            nav.Navigate("Home");
        }

        private void buttonAbout_Click(object sender, RoutedEventArgs e)
        {
            nav.Navigate("About");
        }

        private void buttonHome_Click(object sender, RoutedEventArgs e)
        {
            nav.Navigate("Home");
        }
    }
}
