using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VK.VKUI.Controls;
using Windows.UI.Xaml;

namespace VK.VKUI {
    public class VKUILibrary {
        public static Version Version { get { return GetVersion(); } }

        private static Version GetVersion() {
            return typeof(VKUILibrary).GetTypeInfo().Assembly.GetName().Version;
        }

        public static DataTemplate GetIconTemplate(VKIconName iconName) {
            return (DataTemplate)Application.Current.Resources[iconName.ToString()];
        }
    }
}
