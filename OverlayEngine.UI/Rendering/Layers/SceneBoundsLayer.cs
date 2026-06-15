using Avalonia;
using Avalonia.Media;

namespace OverlayEngine.UI.Rendering.Layers;

public sealed class SceneBoundsLayer : ICanvasLayer
{
    public void Render(DrawingContext context, CanvasRenderContext renderContext)
    {
        if (!renderContext.Settings.ShowBounds)
            return;

        var vp = renderContext.Canvas.Viewport;

        var rect = new Rect(
            vp.OffsetX,
            vp.OffsetY,
            renderContext.Canvas.SceneWidth * vp.Zoom,
            renderContext.Canvas.SceneHeight * vp.Zoom);

        context.DrawRectangle(
            null,
            new Pen(Brushes.DimGray, renderContext.Settings.BoundsThickness),
            rect);
    }
}