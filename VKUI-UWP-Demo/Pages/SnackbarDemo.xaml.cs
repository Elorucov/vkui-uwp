using VKUI_UWP_Demo.Utils;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace VKUI_UWP_Demo.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class SnackbarDemo : Page
    {
        public SnackbarDemo()
        {
            this.InitializeComponent();
            this.InitNavigationTransition();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Demo1_Click(object sender, RoutedEventArgs e)
        {
            Demo1.Show();
        }

        private void Demo2_Click(object sender, RoutedEventArgs e)
        {
            Demo2.Show();
        }

        private void Demo3_Click(object sender, RoutedEventArgs e)
        {
            Demo3.Show();
        }

        private void Demo4_Click(object sender, RoutedEventArgs e)
        {
            Demo4.Show();
        }

        private void Demo5_Click(object sender, RoutedEventArgs e)
        {
            Demo5.Show(10000);
        }

        private void Demo6_Click(object sender, RoutedEventArgs e)
        {
            Demo6.Show();
        }

        private void Demo1_Dismissed(object sender, bool e)
        {
            State.Text = "Первое уведомление скрыто";
        }

        private void Demo2_Dismissed(object sender, bool e)
        {
            State.Text = e ? "Нажато на «Добавить метку»" : "Второе уведомление скрыто";
        }

        private void Demo3_Dismissed(object sender, bool e)
        {
            State.Text = e ? "Нажато на «Подробнее»" : "Третье уведомление скрыто";
        }

        private void Demo4_Dismissed(object sender, bool e)
        {
            State.Text = e ? "Сообщение Эльчину было отменено, и ему теперь грустно..." : "Четвёртое уведомление скрыто";
        }

        private void Demo5_Dismissed(object sender, bool e)
        {
            State.Text = "Пятое уведомление скрыто";
        }

        private void Demo6_Dismissed(object sender, bool e)
        {
            State.Text = "Шестое уведомление скрыто";
        }
    }
}
