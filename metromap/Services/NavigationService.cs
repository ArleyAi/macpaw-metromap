using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MetroMap.Services
{
    class FrameNavigationService
    {
        public string CurrentPage;

        public event EventHandler Navigated;

        public void Navigate(string pageName, string[] parameters = null)
        {
            NavFrame.NavigationService.Navigate(new Uri($"Pages/{pageName}Page.xaml", UriKind.Relative));
            CurrentPage = pageName;
            Navigated.Invoke(this, null);
        }

        public Frame NavFrame { get; set; }

        #region Singleton

        private static FrameNavigationService instanse;

        public static FrameNavigationService GetInstance()
        {
            if (instanse == null)
                instanse = new FrameNavigationService();

            return instanse;
        }
        #endregion

    }
}
