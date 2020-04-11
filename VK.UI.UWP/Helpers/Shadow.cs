using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Shapes;

namespace VK.VKUI.Helpers {
    internal class Shadow {
        public static void Draw(UIElement control, Rectangle shadowRectangle, float blurRadius, float opacity) {
            var compositor = ElementCompositionPreview.GetElementVisual(control).Compositor;
            SpriteVisual _visual = compositor.CreateSpriteVisual();
            _visual.Size = control.RenderSize.ToVector2();
            _visual.Offset = new Vector3(0, 0, 0);

            DropShadow _shadow = compositor.CreateDropShadow();
            _shadow.Offset = new Vector3(0, blurRadius / 4.0f, 0);
            _shadow.BlurRadius = blurRadius;
            _shadow.Color = Colors.Black;
            _shadow.Opacity = opacity;
            _shadow.Mask = shadowRectangle.GetAlphaMask();
            _visual.Shadow = _shadow;
            ElementCompositionPreview.SetElementChildVisual(shadowRectangle, _visual);
        }
    }
}
