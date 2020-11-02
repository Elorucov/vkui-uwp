using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.VKUI.Controls;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace VK.VKUI.Popups {
    public class ScreenSpinner<T> {
        static List<Window> registeredWindows = new List<Window>();
        static Dictionary<Window, Popup> currentlyDisplayedInWindows = new Dictionary<Window, Popup>();

        public async Task<T> ShowAsync(Task task) {
            if (!currentlyDisplayedInWindows.ContainsKey(Window.Current)) {
                Popup popup = new Popup();
                ScreenSpinnerPresenter ssp = new ScreenSpinnerPresenter();
                popup.Child = ssp;

                bool sizeChangedEventRegistered = registeredWindows.Contains(Window.Current);
                if (!sizeChangedEventRegistered) {
                    Window.Current.SizeChanged += (a, b) => {
                        if (!popup.IsOpen) return;
                        Resize(b.Size, popup, ssp);
                    };
                    registeredWindows.Add(Window.Current);
                }

                currentlyDisplayedInWindows.Add(Window.Current, popup);
                popup.IsOpen = true;
                Resize(new Size(Window.Current.Bounds.Width, Window.Current.Bounds.Height), popup, ssp);

                // Execute task
                await Task.Delay(500);
                try {
                    await task.ConfigureAwait(true);
                } catch { }

                // Close popup and return result
                currentlyDisplayedInWindows.Remove(Window.Current);
                popup.IsOpen = false;
                popup.Child = null;

                if (!task.IsFaulted) {
                    if (task is Task<T> otask) {
                        return otask.Result;
                    } else {
                        return default;
                    }
                } else {
                    throw task.Exception;
                }
            } else {
                throw new Exception("ScreenSpinner in this window is already showing.");
            }
        }

        private static void Resize(Size s, Popup popup, ScreenSpinnerPresenter ssp) {
            double w = s.Width;
            double h = s.Height;
            popup.Width = w; popup.Height = h;
            ssp.Width = w; ssp.Height = h;
        }
    }

    public class ScreenSpinner : ScreenSpinner<object> { }
}
