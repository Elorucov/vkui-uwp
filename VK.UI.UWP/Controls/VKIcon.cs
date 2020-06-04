using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace VK.VKUI.Controls {
    public sealed class VKIcon : Control {
        #region Properties

        public static readonly DependencyProperty IdProperty =
        DependencyProperty.Register(nameof(Id), typeof(VKIconName), typeof(Progress), new PropertyMetadata(VKIconName.None));

        public VKIconName Id {
            get { return (VKIconName)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        #endregion

        #region Template elements

        ContentPresenter IconPresenter;

        #endregion

        public VKIcon() {
            this.DefaultStyleKey = typeof(VKIcon);
            long i = RegisterPropertyChangedCallback(IdProperty, (a, b) => DrawIcon((VKIconName)GetValue(b)));
            Unloaded += (a, b) => {
                UnregisterPropertyChangedCallback(IdProperty, i);
            };
        }

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            IconPresenter = (ContentPresenter)GetTemplateChild(nameof(IconPresenter));
            DrawIcon((VKIconName)GetValue(IdProperty));
        }

        #region Internal

        private void DrawIcon(VKIconName name) {
            if (IconPresenter == null) return;
            string iconName = name.ToString();
            if (Double.IsNaN(Width) || Double.IsNaN(Height)) {
                Regex regex = new Regex(@"Icon(\d*)");
                MatchCollection matches = regex.Matches(iconName);
                if (matches.Count > 0) {
                    string size = matches[0].Value.Substring(4);
                    Width = Height = Double.Parse(size);
                }
            }
            IconPresenter.ContentTemplate = name == VKIconName.None ? null : (DataTemplate)Application.Current.Resources[iconName];
        }

        #endregion
    }
}
