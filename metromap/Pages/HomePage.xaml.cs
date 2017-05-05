using FirstFloor.ModernUI.Windows.Controls;
using MetroMap.Models;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomePage : ModernFrame
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void ModernFrame_Loaded(object sender, RoutedEventArgs e)
        {

            var core = MetroCore.GetInstance();

            core.Initialize(@"Map.xml", @"Map.jpg", canvas);

            

            
        }
    }
}
