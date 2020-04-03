using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.UI.UWP.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace VK.UI.UWP.Flyouts {
    public class MenuFlyout : FlyoutBase {
        public ObservableCollection<CellButton> Items { get; set; } = new ObservableCollection<CellButton>();

        public MenuFlyout() { }

        protected override Control CreatePresenter() {
            ScrollViewer sv = new ScrollViewer {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };

            StackPanel sp = new StackPanel();
            foreach(CellButton cb in Items) {
                if (cb.Style == null) cb.Style = (Style)Application.Current.Resources["MenuFlyoutCellButtonStyle"];
                cb.Click += (a, b) => Hide();
                sp.Children.Add(cb);
            }
            sv.Content = sp;

            Controls.FlyoutPresenter fp = new Controls.FlyoutPresenter {
                Style = (Style)Application.Current.Resources["MenuFlyoutStyle"],
                Content = sv
            };
            return fp;
        }
    }
}
