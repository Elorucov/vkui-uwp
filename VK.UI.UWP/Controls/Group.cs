using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace VK.VKUI.Controls
{
    public sealed class Group : ContentControl
    {
        #region Properties

        public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(string), typeof(Group), new PropertyMetadata(default(string)));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register(nameof(Description), typeof(string), typeof(Group), new PropertyMetadata(default(string)));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        #endregion

        public Group()
        {
            this.DefaultStyleKey = typeof(Group);
            long hid = RegisterPropertyChangedCallback(HeaderProperty, (a, b) => SetText(GroupHeader, (string)GetValue(b)));
            long did = RegisterPropertyChangedCallback(DescriptionProperty, (a, b) => SetText(GroupDescription, (string)GetValue(b)));

            Unloaded += (a, b) =>
            {
                UnregisterPropertyChangedCallback(HeaderProperty, hid);
                UnregisterPropertyChangedCallback(DescriptionProperty, did);
            };
        }

        #region Template elements

        TextBlock GroupHeader;
        TextBlock GroupDescription;

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            GroupHeader = (TextBlock)GetTemplateChild(nameof(GroupHeader));
            GroupDescription = (TextBlock)GetTemplateChild(nameof(GroupDescription));
            SetText(GroupHeader, (string)GetValue(HeaderProperty));
            SetText(GroupDescription, (string)GetValue(DescriptionProperty));
        }

        private void SetText(TextBlock tb, string v)
        {
            if (tb == null) return;
            tb.Visibility = String.IsNullOrEmpty(v) ? Visibility.Collapsed : Visibility.Visible;
            if (!String.IsNullOrEmpty(v))
            {
                tb.Text = tb.Name == nameof(GroupHeader) ? v.ToUpperInvariant() : v;
            }
            else
            {
                tb.Text = String.Empty;
            }
        }

        #endregion
    }
}
