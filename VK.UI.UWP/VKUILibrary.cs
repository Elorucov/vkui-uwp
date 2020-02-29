using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VK.UI.UWP {
    public class VKUILibrary {
        public static Version Version { get { return GetVersion(); } }

        private static Version GetVersion() {
            return typeof(VKUILibrary).GetTypeInfo().Assembly.GetName().Version;
        }
    }
}
