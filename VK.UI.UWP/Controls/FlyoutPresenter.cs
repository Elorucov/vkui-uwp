using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VK.UI.UWP.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace VK.UI.UWP.Controls {
    public sealed class FlyoutPresenter : ContentControl {
        public FlyoutPresenter() {
            this.DefaultStyleKey = typeof(FlyoutPresenter);
            Loaded += (a, b) => DrawShadow();
        }

        #region Template elements

        Grid PresenterRoot;
        Rectangle PresenterShadow;

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            PresenterRoot = (Grid)GetTemplateChild(nameof(PresenterRoot));
            PresenterShadow = (Rectangle)GetTemplateChild(nameof(PresenterShadow));
        }

        #endregion

        #region Internal

        private void DrawShadow() {
            Shadow.Draw(PresenterRoot, PresenterShadow, 22, 0.2f);
        }

        #endregion

    }
}
