using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using VK.VKUI.Helpers;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace VK.VKUI.Controls {
    public sealed class Snackbar : ContentControl {

        #region Properties and events

        public static readonly DependencyProperty BeforeIconProperty =
        DependencyProperty.Register(nameof(BeforeIcon), typeof(VKIconName), typeof(Snackbar), new PropertyMetadata(VKIconName.None));

        public VKIconName BeforeIcon {
            get { return (VKIconName)GetValue(BeforeIconProperty); }
            set { SetValue(BeforeIconProperty, value); }
        }

        public static readonly DependencyProperty BeforeIconBackgroundProperty =
        DependencyProperty.Register(nameof(BeforeIconBackground), typeof(SolidColorBrush), typeof(Snackbar), new PropertyMetadata(default(SolidColorBrush)));

        public SolidColorBrush BeforeIconBackground {
            get { return (SolidColorBrush)GetValue(BeforeIconBackgroundProperty); }
            set { SetValue(BeforeIconBackgroundProperty, value); }
        }

        public static readonly DependencyProperty BeforeAvatarProperty =
        DependencyProperty.Register(nameof(BeforeAvatar), typeof(Uri), typeof(Snackbar), new PropertyMetadata(null));

        public Uri BeforeAvatar {
            get { return (Uri)GetValue(BeforeAvatarProperty); }
            set { SetValue(BeforeAvatarProperty, value); }
        }

        //public static readonly DependencyProperty AfterIconProperty =
        //DependencyProperty.Register(nameof(AfterIcon), typeof(VKIconName), typeof(Snackbar), new PropertyMetadata(VKIconName.None));

        //public VKIconName AfterIcon {
        //    get { return (VKIconName)GetValue(AfterIconProperty); }
        //    set { SetValue(AfterIconProperty, value); }
        //}

        //public static readonly DependencyProperty AfterIconBackgroundProperty =
        //DependencyProperty.Register(nameof(AfterIconBackground), typeof(SolidColorBrush), typeof(Snackbar), new PropertyMetadata(default(SolidColorBrush)));

        //public SolidColorBrush AfterIconBackground {
        //    get { return (SolidColorBrush)GetValue(AfterIconBackgroundProperty); }
        //    set { SetValue(AfterIconBackgroundProperty, value); }
        //}

        public static readonly DependencyProperty AfterAvatarProperty =
        DependencyProperty.Register(nameof(AfterAvatar), typeof(Uri), typeof(Snackbar), new PropertyMetadata(null));

        public Uri AfterAvatar {
            get { return (Uri)GetValue(AfterAvatarProperty); }
            set { SetValue(AfterAvatarProperty, value); }
        }

        public static readonly DependencyProperty ActionTextProperty =
        DependencyProperty.Register(nameof(ActionText), typeof(string), typeof(Snackbar), new PropertyMetadata(null));

        public string ActionText {
            get { return (string)GetValue(ActionTextProperty); }
            set { SetValue(ActionTextProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
        DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(Snackbar), new PropertyMetadata(Orientation.Horizontal));

        public Orientation Orientation {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public bool IsShowing { get; private set; } = false;
        public event EventHandler<bool> Dismissed; // bool — dismissed when Action button clicked.
        DispatcherTimer timer = new DispatcherTimer();

        #endregion

        public Snackbar() {
            this.DefaultStyleKey = typeof(Snackbar);
            timer.Tick += (a, b) => {
                Dismiss();
                Dismissed?.Invoke(this, false);
            };
        }

        #region Template elements

        Grid Root;
        Rectangle ShadowRect;
        Grid SnackBarRoot;
        Border BeforeIconContainer;
        ContentPresenter BeforeIconPresenter;
        Ellipse BeforeAva;
        BitmapImage BeforeAvaBitmapImage;
        //Border AfterIconContainer;
        //ContentPresenter AfterIconPresenter;
        Ellipse AfterAva;
        BitmapImage AfterAvaBitmapImage;
        StackPanel Presenter;
        HyperlinkButton ActionButtonForHorizontal;
        HyperlinkButton ActionButtonForVertical;

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            Root = (Grid)GetTemplateChild(nameof(Root));
            ShadowRect = (Rectangle)GetTemplateChild(nameof(ShadowRect));
            SnackBarRoot = (Grid)GetTemplateChild(nameof(SnackBarRoot));
            BeforeIconContainer = (Border)GetTemplateChild(nameof(BeforeIconContainer));
            BeforeIconPresenter = (ContentPresenter)GetTemplateChild(nameof(BeforeIconPresenter));
            BeforeAva = (Ellipse)GetTemplateChild(nameof(BeforeAva));
            BeforeAvaBitmapImage = (BitmapImage)GetTemplateChild(nameof(BeforeAvaBitmapImage));
            //AfterIconContainer = (Border)GetTemplateChild(nameof(AfterIconContainer));
            //AfterIconPresenter = (ContentPresenter)GetTemplateChild(nameof(AfterIconPresenter));
            AfterAva = (Ellipse)GetTemplateChild(nameof(AfterAva));
            AfterAvaBitmapImage = (BitmapImage)GetTemplateChild(nameof(AfterAvaBitmapImage));
            Presenter = (StackPanel)GetTemplateChild(nameof(Presenter));
            ActionButtonForHorizontal = (HyperlinkButton)GetTemplateChild(nameof(ActionButtonForHorizontal));
            ActionButtonForVertical = (HyperlinkButton)GetTemplateChild(nameof(ActionButtonForVertical));

            long bic = RegisterPropertyChangedCallback(BeforeIconProperty, (a, b) => DrawIcon(BeforeIconContainer, BeforeIcon, BeforeIconPresenter));
            //long aic = RegisterPropertyChangedCallback(AfterIconProperty, (a, b) => DrawIcon(AfterIconContainer, AfterIcon, AfterIconPresenter));
            long oc = RegisterPropertyChangedCallback(OrientationProperty, (a, b) => Render());
            long atc = RegisterPropertyChangedCallback(ActionTextProperty, (a, b) => Render());
            long hac = RegisterPropertyChangedCallback(HorizontalAlignmentProperty, (a, b) => Render());

            ActionButtonForHorizontal.Click += (a, b) => {
                Dismiss();
                Dismissed?.Invoke(this, true);
            };
            ActionButtonForVertical.Click += (a, b) => {
                Dismiss();
                Dismissed?.Invoke(this, true);
            };
            SnackBarRoot.LayoutUpdated += (a, b) => {
                ShadowRect.Height = SnackBarRoot.RenderSize.Height;
                Shadow.Draw(SnackBarRoot, ShadowRect, 24, 0.24f);
            };
            SnackBarRoot.SizeChanged += (a, b) => Render();
            Loaded += (a, b) => {
                DrawIcon(BeforeIconContainer, BeforeIcon, BeforeIconPresenter);
                //DrawIcon(AfterIconContainer, AfterIcon, AfterIconPresenter);
                Render();
            };
            Unloaded += (a, b) => {
                UnregisterPropertyChangedCallback(BeforeIconProperty, bic);
                //UnregisterPropertyChangedCallback(AfterIconProperty, aic);
                UnregisterPropertyChangedCallback(OrientationProperty, oc);
                UnregisterPropertyChangedCallback(ActionTextProperty, atc);
                UnregisterPropertyChangedCallback(HorizontalAlignmentProperty, hac);
            };
        }

        #endregion

        #region Public methods

        public async void Show(double durationInMs = 4000) {
            if (durationInMs < 1000) {
                throw new ArgumentException("Value must be higher than 1000", nameof(durationInMs));
            }

            if (IsShowing) return;

            IsShowing = true;

            Root.Opacity = 0; // 🤷‍♂️
            Root.Visibility = Visibility.Visible;
            await Task.Delay(1);
            Root.Opacity = 1; // 🤷‍♂️
            Animate(Windows.UI.Composition.AnimationDirection.Normal);

            // Start timer;
            timer.Interval = TimeSpan.FromMilliseconds(durationInMs);
            timer.Start();
        }

        public async void Dismiss() {
            timer.Stop();
            Animate(Windows.UI.Composition.AnimationDirection.Reverse);
            await Task.Delay(250);
            Root.Visibility = Visibility.Collapsed;
            IsShowing = false;
        }

        #endregion

        #region Private

        private void DrawIcon(Border parent, VKIconName icon, ContentPresenter iconPresenter) {
            if (icon != VKIconName.None) iconPresenter.ContentTemplate = VKUILibrary.GetIconTemplate(icon);
            parent.Visibility = icon == VKIconName.None ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Render() {
            // Avatars has a high priority than Icons
            if (BeforeAvatar != null) {
                BeforeAva.Visibility = Visibility.Visible;
                BeforeAvaBitmapImage.UriSource = BeforeAvatar;
                BeforeIconContainer.Visibility = Visibility.Collapsed;
            } else {
                BeforeAva.Visibility = Visibility.Collapsed;
                BeforeIconContainer.Visibility = BeforeIcon == VKIconName.None ? Visibility.Collapsed : Visibility.Visible;
            }

            if (AfterAvatar != null) {
                AfterAva.Visibility = Visibility.Visible;
                AfterAvaBitmapImage.UriSource = AfterAvatar;
            } else {
                AfterAva.Visibility = Visibility.Collapsed;
            }

            // Check vertical alignment
            if (VerticalAlignment == VerticalAlignment.Stretch || VerticalAlignment == VerticalAlignment.Center)
                throw new ArgumentException("VerticalAlignment must be Top or Bottom.", nameof(VerticalAlignment));

            // Action hyperlink button position
            bool isVertical = Orientation == Orientation.Vertical || AfterAvatar != null || SnackBarRoot.ActualWidth < 360;
            ActionButtonForHorizontal.Visibility = !isVertical && !String.IsNullOrEmpty(ActionText) ? Visibility.Visible : Visibility.Collapsed;
            ActionButtonForVertical.Visibility = isVertical && !String.IsNullOrEmpty(ActionText) ? Visibility.Visible : Visibility.Collapsed;
            Grid.SetColumnSpan(Presenter, Orientation == Orientation.Horizontal ? 1 : 2);
        }

        #endregion

        #region Animations

        private void Animate(Windows.UI.Composition.AnimationDirection direction) {
            double height = Root.ActualHeight + Root.Margin.Top + Root.Margin.Bottom;

            ElementCompositionPreview.SetIsTranslationEnabled(Root, true);
            Visual visual = ElementCompositionPreview.GetElementVisual(Root);
            visual.Offset = new Vector3(0, VerticalAlignment == VerticalAlignment.Top ? (float)-height : (float)height, 0);
            visual.Opacity = 0;
            Compositor compositor = visual.Compositor;

            Vector3KeyFrameAnimation vfa = compositor.CreateVector3KeyFrameAnimation();
            vfa.InsertKeyFrame(1f, new Vector3(0, 0, 0));
            vfa.Duration = TimeSpan.FromMilliseconds(250);
            vfa.Direction = direction;
            vfa.IterationCount = 1;

            ScalarKeyFrameAnimation sfa = compositor.CreateScalarKeyFrameAnimation();
            sfa.InsertKeyFrame(1, 1);
            sfa.Duration = TimeSpan.FromMilliseconds(250);
            sfa.Direction = direction;
            sfa.IterationCount = 1;

            visual.StartAnimation("Offset", vfa);
            visual.StartAnimation("Opacity", sfa);
        }

        #endregion
    }
}