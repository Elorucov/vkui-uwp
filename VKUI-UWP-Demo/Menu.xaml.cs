using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.System;
using Windows.System.Profile;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using VKUI_UWP_Demo.Utils;
using VK.UI.UWP;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace VKUI_UWP_Demo {
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Menu : Page {
        public Menu() {
            this.InitializeComponent();
            this.InitNavigationTransition();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void OnLoad(object sender, RoutedEventArgs e) {
            switch(AnalyticsInfo.VersionInfo.DeviceFamily) {
                case "Windows.Desktop":
                    CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
                    break;
                case "Windows.Mobile":
                    DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait; // force portrait mode;
                    ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseCoreWindow);
                    break;
            }

            LibVersion.Text = VKUILibrary.Version.ToString();
        }

        private async void OpenLink(object sender, RoutedEventArgs e) {
            FrameworkElement el = sender as FrameworkElement;
            string url = (string)el.Tag;
            if(Uri.IsWellFormedUriString(url, UriKind.Absolute)) await Launcher.LaunchUriAsync(new Uri(url));
        }

        private void OpenPage(object sender, RoutedEventArgs e) {
            FrameworkElement el = sender as FrameworkElement;
            Type page = null;
            int id = 0;
            if(!Int32.TryParse(el.Tag.ToString(), out id)) return;
            switch(id) {
                case 1: page = typeof(Pages.Icons); break;
            }
            Frame.Navigate(page, null, new DrillInNavigationTransitionInfo());
        }
    }
}
