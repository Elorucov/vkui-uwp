using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace VK.VKUI.Controls {
    public sealed class Placeholder : ContentControl {
        #region Properties

        public static readonly DependencyProperty IconTemplateProperty =
        DependencyProperty.Register(nameof(IconTemplate), typeof(DataTemplate), typeof(Placeholder), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate IconTemplate {
            get { return (DataTemplate)GetValue(IconTemplateProperty); }
            set { SetValue(IconTemplateProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(string), typeof(Placeholder), new PropertyMetadata(default(string)));

        public string Header {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty ActionButtonTextProperty =
        DependencyProperty.Register(nameof(ActionButtonText), typeof(string), typeof(Placeholder), new PropertyMetadata(default(string)));

        public string ActionButtonText {
            get { return (string)GetValue(ActionButtonTextProperty); }
            set { SetValue(ActionButtonTextProperty, value); }
        }

        public static readonly DependencyProperty ActionButtonStyleProperty =
        DependencyProperty.Register(nameof(ActionButtonStyle), typeof(Style), typeof(Placeholder), new PropertyMetadata(default(Style)));

        public Style ActionButtonStyle {
            get { return (Style)GetValue(ActionButtonStyleProperty); }
            set { SetValue(ActionButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty ActionButtonCommandProperty =
        DependencyProperty.Register(nameof(ActionButtonCommand), typeof(ICommand), typeof(Placeholder), new PropertyMetadata(default(ICommand)));

        public ICommand ActionButtonCommand {
            get { return (ICommand)GetValue(ActionButtonCommandProperty); }
            set { SetValue(ActionButtonCommandProperty, value); }
        }

        public event RoutedEventHandler ActionButtonClick;

        #endregion

        public Placeholder() {
            this.DefaultStyleKey = typeof(Placeholder);
        }

        #region Template elements

        ContentPresenter IconPresenter;
        TextBlock HeaderTextBlock;
        ContentPresenter ContentPresenter;
        Button ActionButton;

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();

            if (GetValue(ActionButtonStyleProperty) == null)
                SetValue(ActionButtonStyleProperty, Application.Current.Resources["VKButtonPrimaryLarge"]);

            IconPresenter = (ContentPresenter)GetTemplateChild(nameof(IconPresenter));
            HeaderTextBlock = (TextBlock)GetTemplateChild(nameof(HeaderTextBlock));
            ActionButton = (Button)GetTemplateChild(nameof(ActionButton));
            ContentPresenter = (ContentPresenter)GetTemplateChild(nameof(ContentPresenter));
            //
            ChangeIconVisibility();
            ChangeHeaderVisibility();
            ChangeActionButtonVisibility();
            //
            long ic = RegisterPropertyChangedCallback(IconTemplateProperty, (a, b) => ChangeIconVisibility());
            long hc = RegisterPropertyChangedCallback(HeaderProperty, (a, b) => ChangeHeaderVisibility());
            long abc = RegisterPropertyChangedCallback(ActionButtonTextProperty, (a, b) => ChangeActionButtonVisibility());
            long cc = RegisterPropertyChangedCallback(ContentProperty, (a, b) => FixContentTextAlignment());

            Loaded += (a, b) => {
                ActionButton.Click += InvokeActionButtonClickEvent;
                ContentPresenter.Loaded += ContentPresenter_Loaded;
            };
            Unloaded += (a, b) => {
                ActionButton.Click -= InvokeActionButtonClickEvent;
                ContentPresenter.Loaded -= ContentPresenter_Loaded;
                UnregisterPropertyChangedCallback(IconTemplateProperty, ic);
                UnregisterPropertyChangedCallback(HeaderProperty, hc);
                UnregisterPropertyChangedCallback(ActionButtonTextProperty, abc);
                UnregisterPropertyChangedCallback(ContentProperty, cc);
            };
        }

        #endregion

        #region Internal

        private void InvokeActionButtonClickEvent(object sender, RoutedEventArgs e) {
            ActionButtonClick?.Invoke(this, e);
        }

        private void ContentPresenter_Loaded(object sender, RoutedEventArgs e) {
            FixContentTextAlignment();
        }

        private void ChangeIconVisibility() {
            IconPresenter.Visibility = GetValue(IconTemplateProperty) != null ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ChangeHeaderVisibility() {
            HeaderTextBlock.Visibility = GetValue(HeaderProperty) != null ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ChangeActionButtonVisibility() {
            ActionButton.Visibility = GetValue(ActionButtonTextProperty) != null ? Visibility.Visible : Visibility.Collapsed;
        }

        private void FixContentTextAlignment() {
            object value = GetValue(ContentProperty);
            if (GetValue(ContentProperty) != null && value is string && ContentPresenter != null) {
                DependencyObject dobj = VisualTreeHelper.GetChild(ContentPresenter, 0);
                if (dobj is TextBlock tb) tb.TextAlignment = TextAlignment.Center;
            }
        }

        #endregion
    }
}
