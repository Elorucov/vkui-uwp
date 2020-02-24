using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.System.Profile;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace VK.UI.UWP.Controls {
    public sealed class PageHeader : ContentControl {

        #region Properties

        public static readonly DependencyProperty DetectNonSafeAreaProperty =
        DependencyProperty.Register(nameof(DetectNonSafeArea), typeof(bool), typeof(PageHeader), new PropertyMetadata(default(bool)));

        public bool DetectNonSafeArea {
            get { return (bool)GetValue(DetectNonSafeAreaProperty); }
            set { SetValue(DetectNonSafeAreaProperty, value); }
        }

        public ObservableCollection<PageHeaderButton> _leftButtons = new ObservableCollection<PageHeaderButton>();
        public ObservableCollection<PageHeaderButton> LeftButtons { get { return _leftButtons; } }

        public ObservableCollection<PageHeaderButton> _rightButtons = new ObservableCollection<PageHeaderButton>();
        public ObservableCollection<PageHeaderButton> RightButtons { get { return _rightButtons; } }

        #endregion

        public PageHeader() {
            this.DefaultStyleKey = typeof(PageHeader);
        }

        #region Template elements

        Grid LayoutRoot;
        StackPanel HeaderLeft;
        StackPanel HeaderRight;

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            LayoutRoot = (Grid)GetTemplateChild(nameof(LayoutRoot));
            HeaderLeft = (StackPanel)GetTemplateChild(nameof(HeaderLeft));
            HeaderRight = (StackPanel)GetTemplateChild(nameof(HeaderRight));

            long dnsaid = RegisterPropertyChangedCallback(DetectNonSafeAreaProperty, FixMarginCallback);
            Loaded += (a, b) => {
                FixMarginCallback(this, DetectNonSafeAreaProperty);
                AddButtonsInStackPanel(HeaderLeft, _leftButtons);
                AddButtonsInStackPanel(HeaderRight, _rightButtons);
                LeftButtons.CollectionChanged += LeftButtons_CollectionChanged;
                RightButtons.CollectionChanged += RightButtons_CollectionChanged;
            };
            Unloaded += (a, b) => {
                UnregisterPropertyChangedCallback(DetectNonSafeAreaProperty, dnsaid);
                LeftButtons.CollectionChanged -= LeftButtons_CollectionChanged;
                RightButtons.CollectionChanged -= RightButtons_CollectionChanged;
                DetectNonSafeArea = false;
            };
        }

        #endregion

        #region Internal

        // Margin for non-safe areas

        private void FixMarginCallback(DependencyObject sender, DependencyProperty dp) {
            bool isEnabled = (bool)GetValue(dp);
            CoreApplicationViewTitleBar titleBar = null;
            ApplicationView view = ApplicationView.GetForCurrentView();
            double margin = 0;
            if (isEnabled) {
                switch(AnalyticsInfo.VersionInfo.DeviceFamily) {
                    case "Windows.Desktop":
                        titleBar = CoreApplication.GetCurrentView().TitleBar;
                        margin = titleBar.Height;
                        titleBar.LayoutMetricsChanged += TitleBar_LayoutMetricsChanged;
                        break;
                    case "Windows.Mobile":
                        margin = view.VisibleBounds.Top;
                        view.VisibleBoundsChanged += View_VisibleBoundsChanged;
                        break;
                }
            } else {
                switch(AnalyticsInfo.VersionInfo.DeviceFamily) {
                    case "Windows.Desktop":
                        if(titleBar != null) titleBar.LayoutMetricsChanged -= TitleBar_LayoutMetricsChanged;
                        break;
                    case "Windows.Mobile":
                        view.VisibleBoundsChanged -= View_VisibleBoundsChanged;
                        break;
                }
            }
            FixMargin(margin);
        }

        private void TitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args) {
            bool isTabletMode = UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Touch;
            FixMargin(isTabletMode ? 0 : sender.Height);
        }

        private void View_VisibleBoundsChanged(ApplicationView sender, object args) {
            FixMargin(sender.VisibleBounds.Top);
        }

        private void FixMargin(double margin = 0) {
            LayoutRoot.Margin = new Thickness(0, margin, 0, 0);
            Debug.WriteLine($"Margin: {margin} px");
        }

        // Buttons

        private void LeftButtons_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            AddButtonsInStackPanel(HeaderLeft, _leftButtons);
        }

        private void RightButtons_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            AddButtonsInStackPanel(HeaderRight, _rightButtons);
        }

        private void AddButtonsInStackPanel(StackPanel panel, ObservableCollection<PageHeaderButton> buttons) {
            panel.Children.Clear();
            foreach(PageHeaderButton button in buttons) {
                panel.Children.Add(button);
            }
        }

        #endregion
    }
}
