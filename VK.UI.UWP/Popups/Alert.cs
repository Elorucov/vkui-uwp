using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using VK.VKUI.Helpers;
using VK.VKUI.Popups;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace VK.VKUI.Popups {
    public enum AlertButton { None, Primary, Secondary }

    public sealed class Alert : ContentControl {
        public Alert() {
            DefaultStyleKey = typeof(Alert);
        }

        AlertButton Result;
        ManualResetEventSlim mres = new ManualResetEventSlim();

        #region Properties

        public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(string), typeof(Alert), new PropertyMetadata(default(string)));

        public string Header {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(Alert), new PropertyMetadata(default(string)));

        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty PrimaryButtonTextProperty =
        DependencyProperty.Register(nameof(PrimaryButtonText), typeof(string), typeof(Alert), new PropertyMetadata(default(string)));

        public string PrimaryButtonText {
            get { return (string)GetValue(PrimaryButtonTextProperty); }
            set { SetValue(PrimaryButtonTextProperty, value); }
        }

        public static readonly DependencyProperty SecondaryButtonTextProperty =
        DependencyProperty.Register(nameof(SecondaryButtonText), typeof(string), typeof(Alert), new PropertyMetadata(default(string)));

        public string SecondaryButtonText {
            get { return (string)GetValue(SecondaryButtonTextProperty); }
            set { SetValue(SecondaryButtonTextProperty, value); }
        }

        #endregion

        #region Template elements

        Popup popup;

        Grid InvisibleLayer;
        Rectangle ShadowBig;
        Rectangle ShadowSmall;
        Grid AlertContainer;
        TextBlock AlertText;
        Button PrimaryButton;
        Button SecondaryButton;

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();

            InvisibleLayer = (Grid)GetTemplateChild(nameof(InvisibleLayer));
            ShadowBig = (Rectangle)GetTemplateChild(nameof(ShadowBig));
            ShadowSmall = (Rectangle)GetTemplateChild(nameof(ShadowSmall));
            AlertContainer = (Grid)GetTemplateChild(nameof(AlertContainer));
            AlertText = (TextBlock)GetTemplateChild(nameof(AlertText));
            PrimaryButton = (Button)GetTemplateChild(nameof(PrimaryButton));
            SecondaryButton = (Button)GetTemplateChild(nameof(SecondaryButton));

            long tid = RegisterPropertyChangedCallback(TextProperty, (a, b) => CheckText());

            long pbid = RegisterPropertyChangedCallback(PrimaryButtonTextProperty, 
                (a, b) => CheckButton(PrimaryButton, (string)GetValue(b)));

            long sbid = RegisterPropertyChangedCallback(SecondaryButtonTextProperty, 
                (a, b) => CheckButton(SecondaryButton, (string)GetValue(b)));

            PrimaryButton.Click += PrimaryButtonClicked;
            SecondaryButton.Click += SecondaryButtonClicked;
            Loaded += OnLoaded;
            InvisibleLayer.LayoutUpdated += InvisibleLayer_LayoutUpdated;
            Window.Current.SizeChanged += OnSizeChanged;

            Unloaded += (a, b) => {
                PrimaryButton.Click -= PrimaryButtonClicked;
                SecondaryButton.Click -= SecondaryButtonClicked;
                Loaded -= OnLoaded;
                InvisibleLayer.LayoutUpdated -= InvisibleLayer_LayoutUpdated;
                Window.Current.SizeChanged -= OnSizeChanged;

                UnregisterPropertyChangedCallback(TextProperty, tid);
                UnregisterPropertyChangedCallback(PrimaryButtonTextProperty, pbid);
                UnregisterPropertyChangedCallback(SecondaryButtonTextProperty, sbid);
            };
        }

        #endregion

        #region Buttons events

        private void PrimaryButtonClicked(object sender, RoutedEventArgs e) {
            Close(AlertButton.Primary);
        }

        private void SecondaryButtonClicked(object sender, RoutedEventArgs e) {
            Close(AlertButton.Secondary);
        }

        #endregion

        #region Public methods

        public async Task<AlertButton> ShowAsync() {
            popup = new Popup();
            popup.Child = this;

            popup.Width = Window.Current.Bounds.Width;
            popup.Height = Window.Current.Bounds.Height;
            Width = Window.Current.Bounds.Width;
            Height = Window.Current.Bounds.Height;

            popup.IsOpen = true;

            await Task.Factory.StartNew(() => {
                mres.Wait();
            }).ConfigureAwait(true);

            Animate(Windows.UI.Composition.AnimationDirection.Reverse, 170);
            await Task.Delay(170);
            popup.IsOpen = false;
            mres.Dispose();
            return Result;
        }

        #endregion

        #region Private methods

        private void Close(AlertButton button) {
            Window.Current.CoreWindow.KeyUp -= CheckPressedButton;
            Result = button;
            mres.Set();
        }

        private void CheckText() {
            AlertText.Visibility = String.IsNullOrEmpty(Text) ? Visibility.Collapsed : Visibility.Visible;
        }

        private void CheckButton(Button button, string text) {
            button.Visibility = String.IsNullOrEmpty(text) ? Visibility.Collapsed : Visibility.Visible;

            // Не должно же быть так, чтобы ни одна кнопка не отображалась...
            if (String.IsNullOrEmpty(PrimaryButtonText) && String.IsNullOrEmpty(SecondaryButtonText)) {
                PrimaryButtonText = "OK";
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e) {
            CheckText();
            CheckButton(PrimaryButton, PrimaryButtonText);
            CheckButton(SecondaryButton, SecondaryButtonText);

            Animate(Windows.UI.Composition.AnimationDirection.Normal, 250);
            PrimaryButton.Focus(FocusState.Programmatic);
            Window.Current.CoreWindow.KeyUp += CheckPressedButton;
        }

        private void CheckPressedButton(CoreWindow sender, KeyEventArgs args) {
            if (args.VirtualKey == Windows.System.VirtualKey.Escape) Close(AlertButton.None);
        }

        private void InvisibleLayer_LayoutUpdated(object sender, object e) {
            DrawShadow();
        }

        private void OnSizeChanged(object sender, WindowSizeChangedEventArgs e) {
            popup.Width = e.Size.Width;
            popup.Height = e.Size.Height;
            Width = e.Size.Width;
            Height = e.Size.Height;
        }

        private void DrawShadow() {
            ShadowBig.Width = AlertContainer.ActualWidth;
            ShadowBig.Height = AlertContainer.ActualHeight;

            ShadowSmall.Width = AlertContainer.ActualWidth;
            ShadowSmall.Height = AlertContainer.ActualHeight;

            VK.VKUI.Helpers.Shadow.Draw(AlertContainer, ShadowBig, 96, 0.16f);
            VK.VKUI.Helpers.Shadow.Draw(AlertContainer, ShadowSmall, 2, 0.12f);
        }

        private void Animate(Windows.UI.Composition.AnimationDirection direction, int duration) {
            ElementCompositionPreview.SetIsTranslationEnabled(InvisibleLayer, true);
            Visual dvisual = ElementCompositionPreview.GetElementVisual(InvisibleLayer);
            Compositor dcompositor = dvisual.Compositor;

            var size = Window.Current.Bounds;
            float cx = (float)size.Width / 2;
            float cy = (float)size.Height / 2;

            dvisual.Scale = new Vector3(1.13f, 1.13f, 1);
            dvisual.Opacity = 0;
            dvisual.CenterPoint = new Vector3(cx, cy, 1);

            Vector3KeyFrameAnimation vfa = dcompositor.CreateVector3KeyFrameAnimation();
            vfa.InsertKeyFrame(1f, new Vector3(1, 1, 1));
            vfa.Duration = TimeSpan.FromMilliseconds(duration);
            vfa.Direction = direction;
            vfa.IterationCount = 1;

            ScalarKeyFrameAnimation sdfa = dcompositor.CreateScalarKeyFrameAnimation();
            sdfa.InsertKeyFrame(1, 1);
            sdfa.Duration = TimeSpan.FromMilliseconds(duration);
            sdfa.Direction = direction;
            sdfa.IterationCount = 1;

            dvisual.StartAnimation("Scale", vfa);
            dvisual.StartAnimation("Opacity", sdfa);
        }

        #endregion
    }
}