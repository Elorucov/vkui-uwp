using VK.VKUI.Popups;
using VKUI_UWP_Demo.Utils;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VKUI_UWP_Demo.Pages {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AlertDemo : Page {
        public AlertDemo() {
            this.InitializeComponent();
            this.InitNavigationTransition();
        }

        private void GoBack(object sender, RoutedEventArgs e) {
            Frame.GoBack();
        }

        private async void Demo1_Click(object sender, RoutedEventArgs e) {
            CheckBox cb = new CheckBox {
                Style = (Style)Application.Current.Resources["VKCheckBox"],
                Margin = new Thickness(0, 8, 0, 0),
                Content = "Удалить для всех"
            };

            Alert alert = new Alert { 
                Header = "Удаление сообщения",
                Text = "Вы уверены, что хотите удалить это сообщение?",
                PrimaryButtonText = "Удалить",
                SecondaryButtonText = "Отмена",
                Content = cb
            };
            AlertButton result = await alert.ShowAsync();
            Result.Text = $"Clicked button: {result}. Checkbox: {cb.IsChecked}.";
        }

        private async void Demo2_Click(object sender, RoutedEventArgs e) {
            Alert alert = new Alert {
                Header = "Ошибка",
                Text = "Вы попытались загрузить более одной однотипной страницы в секунду. Вернитесь назад и повторите попытку."
            };
            AlertButton result = await alert.ShowAsync();
            Result.Text = $"Clicked button: {result}.";
        }

        private async void Demo3_Click(object sender, RoutedEventArgs e) {
            TextBox tb = new TextBox {
                Style = (Style)Application.Current.Resources["VKTextBox"],
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 8, 0, 0)
            };

            Alert alert = new Alert {
                Header = "Введите что-нибудь",
                PrimaryButtonText = "Отправить",
                SecondaryButtonText = "Отмена",
                Content = tb
            };
            AlertButton result = await alert.ShowAsync();
            Result.Text = $"Clicked button: {result}. Text: {tb.Text}.";
        }
    }
}