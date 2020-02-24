using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace VKUI_UWP_Demo.Utils {
    public static class Extensions {
        public static void InitNavigationTransition(this Page sourcePage) {
            sourcePage.Transitions = new TransitionCollection() {
                new NavigationThemeTransition() {
                    DefaultNavigationTransitionInfo = new DrillInNavigationTransitionInfo()
                }
            };
        }
    }
}
