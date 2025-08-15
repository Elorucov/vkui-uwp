using System;
using System.Collections.ObjectModel;
using VK.VKUI.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace VK.VKUI.Popups
{
    public class MenuFlyout : FlyoutBase
    {
        public ObservableCollection<Control> Items { get; set; } = new ObservableCollection<Control>();

        public MenuFlyout()
        {
            Closed += (d, e) =>
            {
                foreach (Control c in Items)
                {
                    if (c is CellButton cb)
                    {
                        cb.Click -= (a, b) => Hide();
                    }
                    else if (c is MenuFlyoutItem mfi)
                    {
                        mfi.Click -= (a, b) => Hide();
                    }
                    else if (c is RadioButton rb)
                    {
                        rb.Click -= (a, b) => Hide();
                    }
                }
            };
        }

        protected override Control CreatePresenter()
        {
            ScrollViewer sv = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };

            StackPanel sp = new StackPanel();
            foreach (Control c in Items)
            {
                if (c is CellButton cb)
                {
                    if (cb.Style == null) cb.Style = (Style)Application.Current.Resources["MenuFlyoutCellButtonStyle"];
                    cb.Click += (a, b) => Hide();
                    sp.Children.Add(cb);
                }
                else if (c is MenuFlyoutItem mfi)
                {
                    if (mfi.Style == null) mfi.Style = (Style)Application.Current.Resources["VKUIMenuFlyoutItemStyle"];
                    mfi.Click += (a, b) => Hide();
                    sp.Children.Add(mfi);
                }
                else if (c is RadioButton rb)
                {
                    if (rb.Style == null) rb.Style = (Style)Application.Current.Resources["VKUIRadioButtonForFlyoutStyle"];
                    rb.Click += (a, b) => Hide();
                    sp.Children.Add(rb);
                }
                else if (c is MenuFlyoutSeparator mfs)
                {
                    if (mfs.Style == null) mfs.Style = (Style)Application.Current.Resources["VKUIMenuFlyoutSeparatorStyle"];
                    sp.Children.Add(mfs);
                }
                else
                {
                    throw new ArgumentException($"Items must contain only objects of these types: {nameof(CellButton)}, {nameof(MenuFlyoutItem)} and {nameof(MenuFlyoutSeparator)}");
                }
            }
            sv.Content = sp;

            Controls.FlyoutPresenter fp = new Controls.FlyoutPresenter
            {
                Style = (Style)Application.Current.Resources["MenuFlyoutStyle"],
                Content = sv
            };
            return fp;
        }
    }
}
