using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace VK.VKUI.Flyouts {
    public class Flyout : FlyoutBase {
        public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(nameof(Content), typeof(FrameworkElement), typeof(Flyout), new PropertyMetadata(default(FrameworkElement)));

        public FrameworkElement Content {
            get { return (FrameworkElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public Flyout() { }

        protected override Control CreatePresenter() {
            Controls.FlyoutPresenter fp = new Controls.FlyoutPresenter {
                Content = Content
            };
            return fp;
        }
    }
}
