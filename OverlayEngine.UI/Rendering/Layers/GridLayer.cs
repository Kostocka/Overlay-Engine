using Avalonia;
using Avalonia.Media;

namespace OverlayEngine.UI.Rendering.Layers;

public sealed class GridLayer : ICanvasLayer
{
    public void Render(DrawingContext context, CanvasRenderContext renderContext)
    {
        if (!renderContext.Settings.ShowGrid)
            return;

        var vp = renderContext.Canvas.Viewport;

        var step = 50.0 * vp.Zoom;

        if (step < 10)
            return;

        var width = renderContext.Canvas.SceneWidth * vp.Zoom;
        var height = renderContext.Canvas.SceneHeight * vp.Zoom;
        var left = vp.OffsetX;
        var top = vp.OffsetY;

        var pen = new Pen(Brushes.Gray, 1);

        for (var x = left; x <= left + width; x += step)
        {
            context.DrawLine(
                pen,
                new Point(x, top),
                new Point(x, top + height));
        }

        for (var y = top; y <= top + height; y += step)
        {
            context.DrawLine(
                pen,
                new Point(left, y),
                new Point(left + width, y));
        }
    }
}