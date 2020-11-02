using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using VK.VKUI.Popups;
using VKUI_UWP_Demo.Utils;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace VKUI_UWP_Demo.Pages {
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ScreenSpinnerDemo : Page {
        public ScreenSpinnerDemo() {
            this.InitializeComponent();
            this.InitNavigationTransition();
        }

        private void GoBack(object sender, RoutedEventArgs e) {
            Frame.GoBack();
        }

        private async void Demo1_Click(object sender, RoutedEventArgs e) {
            ScreenSpinner ss = new ScreenSpinner();
            await ss.ShowAsync(Demo1());
        }

        private async void Demo2_Click(object sender, RoutedEventArgs e) {
            ScreenSpinner<string> ss = new ScreenSpinner<string>();
            string result = await ss.ShowAsync(Demo2(42));
            await new MessageDialog(result, "Результат").ShowAsync();
        }

        private async void Demo3_Click(object sender, RoutedEventArgs e) {
            ScreenSpinner ss = new ScreenSpinner();
            try {
                await ss.ShowAsync(Demo3());
            } catch (Exception ex) {
                await new MessageDialog($"HResult: 0x{ex.HResult.ToString("x8")}\n{ex.Message}", "Exception info").ShowAsync();
            }
        }

        private async Task Demo1() {
            await Task.Delay(3000);
        }

        private async Task<string> Demo2(int data) {
            await Task.Delay(1000);
            return $"Ваше число — {data}";
        }

        private async Task Demo3() {
            await Task.Delay(1000);
            throw new Exception("Some exception.");
        }
    }
}
