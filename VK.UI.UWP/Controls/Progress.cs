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
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace VK.UI.UWP.Controls {
    public sealed class Progress : Control {

        #region Properties

        public static readonly DependencyProperty MaximumProperty =
        DependencyProperty.Register(nameof(Maximum), typeof(double), typeof(Progress), new PropertyMetadata(default(double)));

        public double Maximum {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(double), typeof(Progress), new PropertyMetadata(default(double)));

        public double Value {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        #endregion

        public Progress() {
            this.DefaultStyleKey = typeof(Progress);
        }

        #region Template elements

        Grid LayoutRoot;
        Rectangle ProgressFill;

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            LayoutRoot = (Grid)GetTemplateChild(nameof(LayoutRoot));
            ProgressFill = (Rectangle)GetTemplateChild(nameof(ProgressFill));
            Update();
            long mpid = RegisterPropertyChangedCallback(MaximumProperty, (a, b) => Update());
            long vpid = RegisterPropertyChangedCallback(ValueProperty, (a, b) => Update());
            SizeChanged += Progress_SizeChanged;
            Unloaded += (a, b) => {
                SizeChanged -= Progress_SizeChanged;
                UnregisterPropertyChangedCallback(MaximumProperty, mpid);
                UnregisterPropertyChangedCallback(ValueProperty, vpid);
            };
        }

        #endregion

        #region Internal

        private void Progress_SizeChanged(object sender, SizeChangedEventArgs e) {
            Update();
        }

        private void Update() {
            double pfw = LayoutRoot.ActualWidth / Maximum * Value;
            ProgressFill.Width = LayoutRoot.ActualWidth;
            (ProgressFill.RenderTransform as CompositeTransform).TranslateX = Value > Maximum ? 0 : pfw - LayoutRoot.ActualWidth;
        }

        #endregion
    }
}
