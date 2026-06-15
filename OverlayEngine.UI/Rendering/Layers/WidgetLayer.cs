using Avalonia;
using Avalonia.Media;

namespace OverlayEngine.UI.Rendering.Layers;

public sealed class WidgetLayer : ICanvasLayer
{
    public void Render(DrawingContext context, CanvasRenderContext renderContext)
    {
        foreach (var widget in renderContext.Canvas.Widgets)
        {
            var renderer = renderContext.Renderers.Get(widget);

            var screenRect = renderContext.Transform.SceneToScreen(
                new Rect(widget.X, widget.Y, widget.Width, widget.Height));

            var widgetRenderContext = new WidgetRenderContext(
                new WidgetDrawArea(
                    screenRect.X,
                    screenRect.Y,
                    screenRect.Width,
                    screenRect.Height));

            renderer.Render(context, widget, widgetRenderContext);
        }
    }
}