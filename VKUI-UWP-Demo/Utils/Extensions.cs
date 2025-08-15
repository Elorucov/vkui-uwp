using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace VKUI_UWP_Demo.Utils
{
    public static class Extensions
    {
        public static void InitNavigationTransition(this Page sourcePage)
        {
            sourcePage.Transitions = new TransitionCollection() {
                new NavigationThemeTransition() {
                    DefaultNavigationTransitionInfo = new DrillInNavigationTransitionInfo()
                }
            };
        }
    }
}
