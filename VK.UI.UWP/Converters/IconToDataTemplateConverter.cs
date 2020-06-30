using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.VKUI.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VK.VKUI.Converters {
    public class IconToDataTemplateConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            System.Diagnostics.Debug.WriteLine($"IconToDataTemplateConverter: value = {value}");
            if (value is VKIconName i && targetType == typeof(DataTemplate))
                return i != VKIconName.None ? VKUILibrary.GetIconTemplate(i) : null;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return DependencyProperty.UnsetValue;
        }
    }
}
