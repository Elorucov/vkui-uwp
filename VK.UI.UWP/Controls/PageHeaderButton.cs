using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed class PageHeaderButton : ButtonBase {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(VKIconName), typeof(CellButton), new PropertyMetadata(default(VKIconName)));

        public VKIconName Icon {
            get { return (VKIconName)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(PageHeaderButton), new PropertyMetadata(default(string)));

        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public PageHeaderButton() {
            this.DefaultStyleKey = typeof(PageHeaderButton);
        }

        #region Template elements

        ContentPresenter IconPresenter;

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            IconPresenter = (ContentPresenter)GetTemplateChild(nameof(IconPresenter));

            RegisterPropertyChangedCallback(TextProperty, (c, d) => ToolTipService.SetToolTip(this, GetValue(d)));
            long ieid = RegisterPropertyChangedCallback(IsEnabledProperty, (a, b) => CheckIsEnabled());
            long iid = RegisterPropertyChangedCallback(IconProperty, (a, b) => DrawIcon((VKIconName)GetValue(b)));

            Loaded += (a, b) => {
                ToolTipService.SetToolTip(this, GetValue(TextProperty));
                CheckIsEnabled();
                AddHandler(UIElement.PointerEnteredEvent, new PointerEventHandler(Entered), true);
                AddHandler(UIElement.PointerExitedEvent, new PointerEventHandler(Exited), true);
                AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(Pressed), true);
                AddHandler(UIElement.PointerReleasedEvent, new PointerEventHandler(Released), true);
                AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(KbdDown), true);
                AddHandler(UIElement.KeyUpEvent, new KeyEventHandler(KbdUp), true);
                DrawIcon(Icon);
            };
            LayoutUpdated += PageHeaderButton_LayoutUpdated;
            Unloaded += (a, b) => {
                RemoveHandler(UIElement.PointerEnteredEvent, new PointerEventHandler(Entered));
                RemoveHandler(UIElement.PointerExitedEvent, new PointerEventHandler(Exited));
                RemoveHandler(UIElement.PointerPressedEvent, new PointerEventHandler(Pressed));
                RemoveHandler(UIElement.PointerReleasedEvent, new PointerEventHandler(Released));
                RemoveHandler(UIElement.KeyDownEvent, new KeyEventHandler(KbdDown));
                RemoveHandler(UIElement.KeyUpEvent, new KeyEventHandler(KbdUp));
                UnregisterPropertyChangedCallback(IsEnabledProperty, ieid);
                UnregisterPropertyChangedCallback(IconProperty, iid);
                LayoutUpdated -= PageHeaderButton_LayoutUpdated;
            };
        }

        #endregion

        #region Internal

        private void CheckIsEnabled() {
            VisualStateManager.GoToState(this, IsEnabled ? ButtonStates.Normal : ButtonStates.Disabled, true);
        }

        private void PageHeaderButton_LayoutUpdated(object sender, object e) {
            DrawIcon(Icon);
        }

        private void DrawIcon(VKIconName iconName) {
            Debug.WriteLine($"PageHeaderButton: drawing {iconName}");
            IconPresenter.ContentTemplate = VKUILibrary.GetIconTemplate(iconName);
        }

        // States

        bool isPressing = false;
        bool isPointerOver = false;

        private void Entered(object sender, PointerRoutedEventArgs e) {
            if(!IsEnabled) return;
            isPointerOver = true;
            VisualStateManager.GoToState(this, isPressing ? ButtonStates.Pressed : ButtonStates.PointerOver, true);
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Hand, 0);
        }

        private void Exited(object sender, PointerRoutedEventArgs e) {
            if(!IsEnabled) return;
            isPointerOver = false;
            VisualStateManager.GoToState(this, ButtonStates.Normal, true);
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Arrow, 0);
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
            if (e.Key == Windows.System.VirtualKey.Enter || e.Key == Windows.System.VirtualKey.Space)
                VisualStateManager.GoToState(this, ButtonStates.Pressed, true);
        }

        private void KbdUp(object sender, KeyRoutedEventArgs e) {
            VisualStateManager.GoToState(this, ButtonStates.Normal, true);
        }

        #endregion
    }
}
