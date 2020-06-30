using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace VK.VKUI.Controls {

    [TemplateVisualState(Name = ButtonStates.Normal, GroupName = ButtonStates.Name)]
    [TemplateVisualState(Name = ButtonStates.PointerOver, GroupName = ButtonStates.Name)]
    [TemplateVisualState(Name = ButtonStates.Pressed, GroupName = ButtonStates.Name)]
    [TemplateVisualState(Name = ButtonStates.Disabled, GroupName = ButtonStates.Name)]
    public sealed class CellButton : ButtonBase {

        #region Properties

        public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(VKIconName), typeof(CellButton), new PropertyMetadata(VKIconName.None));

        public VKIconName Icon {
            get { return (VKIconName)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconTemplateProperty =
        DependencyProperty.Register(nameof(IconTemplate), typeof(DataTemplate), typeof(CellButton), new PropertyMetadata(null));

        public DataTemplate IconTemplate {
            get { return (DataTemplate)GetValue(IconTemplateProperty); }
            set { SetValue(IconTemplateProperty, value); }
        }

        public static readonly DependencyProperty IconBrushProperty =
        DependencyProperty.Register(nameof(IconBrush), typeof(Brush), typeof(CellButton), new PropertyMetadata(default(Brush)));

        public Brush IconBrush {
            get { return (Brush)GetValue(IconBrushProperty); }
            set { SetValue(IconBrushProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(CellButton), new PropertyMetadata(default(string)));

        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty IndicatorProperty =
        DependencyProperty.Register(nameof(Indicator), typeof(object), typeof(CellButton), new PropertyMetadata(default(object)));

        public object Indicator {
            get { return (object)GetValue(IndicatorProperty); }
            set { SetValue(IndicatorProperty, value); }
        }

        public static readonly DependencyProperty IndicatorTemplateProperty =
        DependencyProperty.Register(nameof(IndicatorTemplate), typeof(ControlTemplate), typeof(CellButton), new PropertyMetadata(default(ControlTemplate)));

        public ControlTemplate IndicatorTemplate {
            get { return (ControlTemplate)GetValue(IndicatorTemplateProperty); }
            set { SetValue(IndicatorTemplateProperty, value); }
        }

        #endregion

        public CellButton() {
            this.DefaultStyleKey = typeof(CellButton);
        }

        #region Template elements

        Grid LayoutRoot;
        ContentPresenter IconPresenter;
        ContentControl IndicatorPresenter;

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            LayoutRoot = (Grid)GetTemplateChild(nameof(LayoutRoot));
            IconPresenter = (ContentPresenter)GetTemplateChild(nameof(IconPresenter));
            IndicatorPresenter = (ContentControl)GetTemplateChild(nameof(IndicatorPresenter));
            ShowHideIcon();
            CheckIsEnabled();
            long itid = RegisterPropertyChangedCallback(IconProperty, (a, b) => ShowHideIcon());
            long ieid = RegisterPropertyChangedCallback(IsEnabledProperty, (a, b) => CheckIsEnabled());
            Loaded += (a, b) => {
                ShowHideIcon();
                AddHandler(UIElement.PointerEnteredEvent, new PointerEventHandler(Entered), true);
                AddHandler(UIElement.PointerExitedEvent, new PointerEventHandler(Exited), true);
                AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(Pressed), true);
                AddHandler(UIElement.PointerReleasedEvent, new PointerEventHandler(Released), true);
                AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(KbdDown), true);
                AddHandler(UIElement.KeyUpEvent, new KeyEventHandler(KbdUp), true);
            };
            Unloaded += (a, b) => {
                RemoveHandler(UIElement.PointerEnteredEvent, new PointerEventHandler(Entered));
                RemoveHandler(UIElement.PointerExitedEvent, new PointerEventHandler(Exited));
                RemoveHandler(UIElement.PointerPressedEvent, new PointerEventHandler(Pressed));
                RemoveHandler(UIElement.PointerReleasedEvent, new PointerEventHandler(Released));
                RemoveHandler(UIElement.KeyDownEvent, new KeyEventHandler(KbdDown));
                RemoveHandler(UIElement.KeyUpEvent, new KeyEventHandler(KbdUp));
                UnregisterPropertyChangedCallback(IsEnabledProperty, ieid);
            };
        }

        #endregion

        #region Internal

        internal void ShowHideIcon() {
            if (IconPresenter != null) {
                if (Tag != null && Tag.ToString() == "debug") System.Diagnostics.Debug.WriteLine($"CellButton: icon id = {Icon}");
                if (Icon != VKIconName.None) IconTemplate = VKUILibrary.GetIconTemplate(Icon);
                IconPresenter.Visibility = IconTemplate == null ? Visibility.Collapsed : Visibility.Visible;
            }
            
        }

        private void CheckIsEnabled() {
            VisualStateManager.GoToState(this, IsEnabled ? ButtonStates.Normal : ButtonStates.Disabled, true);
        }

        // States

        bool isPressing = false;
        bool isPointerOver = false;

        private void Entered(object sender, PointerRoutedEventArgs e) {
            if(!IsEnabled) return;
            isPointerOver = true;
            VisualStateManager.GoToState(this, isPressing ? ButtonStates.Pressed : ButtonStates.PointerOver, true);
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 0);
        }

        private void Exited(object sender, PointerRoutedEventArgs e) {
            if(!IsEnabled) return;
            isPointerOver = false;
            VisualStateManager.GoToState(this, ButtonStates.Normal, true);
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0);
        }

        private void Pressed(object sender, PointerRoutedEventArgs e) {
            if(!IsEnabled) return;
            isPressing = true;
            VisualStateManager.GoToState(this, ButtonStates.Pressed, true);
        }

        private void Released(object sender, PointerRoutedEventArgs e) {
            isPressing = false;
            VisualStateManager.GoToState(this, isPointerOver ? ButtonStates.PointerOver : ButtonStates.Normal, true);
        }

        private void KbdDown(object sender, KeyRoutedEventArgs e) {
            if(e.Key == Windows.System.VirtualKey.Enter || e.Key == Windows.System.VirtualKey.Space)
                VisualStateManager.GoToState(this, ButtonStates.Pressed, true);
        }

        private void KbdUp(object sender, KeyRoutedEventArgs e) {
            VisualStateManager.GoToState(this, ButtonStates.Normal, true);
        }

        #endregion
    }
}
