using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace VK.VKUI.Popups {
    public class Flyout : FlyoutBase {
        public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(nameof(Content), typeof(FrameworkElement), typeof(Flyout), new PropertyMetadata(default(FrameworkElement)));

        public FrameworkElement Content {
            get { return (FrameworkElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty PresenterStyleProperty =
        DependencyProperty.Register(nameof(PresenterStyle), typeof(Style), typeof(Flyout), new PropertyMetadata(default(FrameworkElement)));

        public Style PresenterStyle {
            get { return (Style)GetValue(PresenterStyleProperty); }
            set { SetValue(PresenterStyleProperty, value); }
        }

        public Flyout() { }

        protected override Control CreatePresenter() {
            Controls.FlyoutPresenter fp = new Controls.FlyoutPresenter {
                Content = Content
            };
            if (PresenterStyle != null) fp.Style = PresenterStyle;
            RegisterPropertyChangedCallback(PresenterStyleProperty, (a, b) => { fp.Style = (Style)GetValue(b); });
            return fp;
        }
    }
}
