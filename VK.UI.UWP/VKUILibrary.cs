using System;
using System.Reflection;
using VK.VKUI.Controls;
using Windows.UI.Xaml;

namespace VK.VKUI
{
    public class VKUILibrary
    {
        public static Version Version { get { return GetVersion(); } }

        private static Version GetVersion()
        {
            return typeof(VKUILibrary).GetTypeInfo().Assembly.GetName().Version;
        }

        public static DataTemplate GetIconTemplate(VKIconName iconName)
        {
            var resources = Application.Current.Resources;
            if (resources.ContainsKey(iconName.ToString())) return (DataTemplate)resources[iconName.ToString()];
            return null;
        }
    }
}
