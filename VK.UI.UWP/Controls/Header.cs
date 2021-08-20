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
    public enum HeaderMode { Primary, Secondary, Tertiary }

    [TemplateVisualState(Name = HeaderStates.Primary, GroupName = HeaderStates.Mode)]
    [TemplateVisualState(Name = HeaderStates.Secondary, GroupName = HeaderStates.Mode)]
    [TemplateVisualState(Name = HeaderStates.Tertiary, GroupName = HeaderStates.Mode)]
    public sealed class Header : ContentControl {
        public Header() {
            this.DefaultStyleKey = typeof(Header);
        }

        #region Properties

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register(nameof(Mode), typeof(HeaderMode), typeof(Header), new PropertyMetadata(default(HeaderMode)));

        public HeaderMode Mode {
            get { return (HeaderMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.Register(nameof(TextWrapping), typeof(TextWrapping), typeof(Header), new PropertyMetadata(default(TextWrapping)));

        public TextWrapping TextWrapping {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }

        #endregion

        #region Template

        TextBlock HeaderText;

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            HeaderText = (TextBlock)GetTemplateChild(nameof(HeaderText));
            long mid = RegisterPropertyChangedCallback(ModeProperty, (a, b) => CheckMode());
            long tid = RegisterPropertyChangedCallback(ContentProperty, (a, b) => SetContent());
            Unloaded += (a, b) => {
                UnregisterPropertyChangedCallback(ModeProperty, mid);
            };
            CheckMode();
        }

        private void CheckMode() {
            string mode = Mode.ToString();
            VisualStateManager.GoToState(this, mode, true);
            SetContent();
        }
        private void SetContent() {
            if (Content is string t) {
                HeaderText.Text = Mode == HeaderMode.Secondary ? t.ToUpper() : t;
            } else {
                throw new ArgumentException("Only string is supported yet", nameof(Content));
            }
        }

        #endregion
    }
}