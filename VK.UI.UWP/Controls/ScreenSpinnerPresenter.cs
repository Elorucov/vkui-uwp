using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using VK.VKUI.Helpers;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace VK.VKUI.Controls {
    internal sealed class ScreenSpinnerPresenter : Control {
        public ScreenSpinnerPresenter() {
            this.DefaultStyleKey = typeof(ScreenSpinnerPresenter);
        }

        #region Template elements

        Grid InvisibleLayer;
        Rectangle ShadowBig;
        Rectangle ShadowSmall;
        Border Container;
        Button FocusableButton;

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            InvisibleLayer = (Grid)GetTemplateChild(nameof(InvisibleLayer));
            ShadowBig = (Rectangle)GetTemplateChild(nameof(ShadowBig));
            ShadowSmall = (Rectangle)GetTemplateChild(nameof(ShadowSmall));
            Container = (Border)GetTemplateChild(nameof(Container));
            FocusableButton = (Button)GetTemplateChild(nameof(FocusableButton));

            Container.LayoutUpdated += (a, b) => {
                Shadow.Draw(Container, ShadowBig, 96, 0.16f);
                Shadow.Draw(Container, ShadowSmall, 2, 0.12f);
            };

            Animate(Windows.UI.Composition.AnimationDirection.Normal);
            FocusableButton.Focus(FocusState.Programmatic);
        }

        #endregion

        #region Internal methods

        internal void Animate(Windows.UI.Composition.AnimationDirection direction) {
            ElementCompositionPreview.SetIsTranslationEnabled(InvisibleLayer, true);
            Visual visual = ElementCompositionPreview.GetElementVisual(InvisibleLayer);
            visual.Opacity = 0;
            Compositor compositor = visual.Compositor;

            ScalarKeyFrameAnimation sfa = compositor.CreateScalarKeyFrameAnimation();
            sfa.InsertKeyFrame(1, 1);
            sfa.Duration = TimeSpan.FromMilliseconds(500);
            sfa.Direction = direction;
            sfa.IterationCount = 1;

            visual.StartAnimation("Opacity", sfa);
        }

        #endregion
    }
}
