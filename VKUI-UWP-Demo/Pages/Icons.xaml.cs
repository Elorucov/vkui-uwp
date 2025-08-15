using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using VKUI_UWP_Demo.Utils;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace VKUI_UWP_Demo.Pages
{
    class IconGroup : ObservableCollection<IconItem>, IComparable
    {
        public double Size { get; private set; }

        public IconGroup(double size, ObservableCollection<IconItem> icons) : base(icons)
        {
            Size = size;
        }

        public int CompareTo(object obj)
        {
            if (obj is IconGroup ig)
            {
                return Size.CompareTo(ig.Size);
            }
            throw new InvalidOperationException("No comparable TKey.");
        }
    }

    class IconItem : IComparable
    {
        public DataTemplate IconTemplate { get; private set; }
        public double Size { get; private set; }
        public string Name { get; private set; }

        public IconItem(DataTemplate icon, double size, string name)
        {
            IconTemplate = icon;
            Size = size;
            Name = name;
        }

        public int CompareTo(object obj)
        {
            if (obj is IconItem ii)
            {
                return Name.CompareTo(ii.Name);
            }
            throw new InvalidOperationException("No comparable TKey.");
        }
    }

    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Icons : Page
    {
        public Icons()
        {
            this.InitializeComponent();
            this.InitNavigationTransition();
        }

        ObservableCollection<IconGroup> VKIcons = new ObservableCollection<IconGroup>();

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            GroupedIcons.Source = VKIcons;
            int count = 0;
            ResourceDictionary iconsdict = App.Current.Resources.MergedDictionaries[3];
            var q = (from i in iconsdict select i).ToList();
            foreach (var i in q)
            {
                if (i.Key is string k && k.Length > 6 && k.Substring(0, 4) == "Icon" && i.Value is DataTemplate v)
                {
                    double s = 0;
                    if (!Double.TryParse(k.Substring(4, 2), out s)) return;

                    IconItem icon = new IconItem(v, s, k);

                    var gq = from g in VKIcons where g.Size == s select g;
                    if (gq.Count() == 0)
                    {
                        IconGroup ig = new IconGroup(s, new ObservableCollection<IconItem> { icon });
                        int idx = VKIcons.ToList().BinarySearch(ig);
                        if (idx < 0) idx = ~idx;
                        VKIcons.Insert(idx, ig);
                    }
                    else if (gq.Count() == 1)
                    {
                        IconGroup ig = gq.First();
                        int idx = ig.ToList().BinarySearch(icon);
                        if (idx < 0) idx = ~idx;
                        ig.Insert(idx, icon);
                    }
                    count++;
                }
            }
            Debug.WriteLine($"Icons count: {count}");
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void ShowIconInfo(object sender, ItemClickEventArgs e)
        {
            IconItem icon = e.ClickedItem as IconItem;
            await new MessageDialog("", icon.Name).ShowAsync();
        }
    }
}
