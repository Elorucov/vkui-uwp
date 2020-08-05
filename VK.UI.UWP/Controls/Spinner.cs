using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace VK.VKUI.Controls {
    public sealed class Spinner : Control {

        #region Template elements

        ContentPresenter SpinnerContainer;
        RotateTransform SpinnerRotator;

        #endregion

        public Spinner() {
            this.DefaultStyleKey = typeof(Spinner);
        }

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            SpinnerContainer = (ContentPresenter)GetTemplateChild(nameof(SpinnerContainer));
            SpinnerRotator = SpinnerContainer.RenderTransform as RotateTransform;
            ShowSpinner(Math.Min(ActualWidth, ActualHeight));
            SizeChanged += OnSizeChanged;
            Unloaded += (c, d) => SizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e) {
            double s = Math.Min(e.NewSize.Width, e.NewSize.Height);
            ShowSpinner(s);
        }

        private void ShowSpinner(double s) {
            double ss = GetSpinnerSize(s);
            SpinnerRotator.CenterX = ss / 2;
            SpinnerRotator.CenterY = ss / 2;
            SpinnerContainer.ContentTemplate = Application.Current.Resources[$"Icon{ss}Spinner"] as DataTemplate;
        }

        private double GetSpinnerSize(double s) {
            if (s >= 38) return 44;
            if (s >= 28) return 32;
            if (s >= 20) return 24;
            return 16;
        }
    }
}
