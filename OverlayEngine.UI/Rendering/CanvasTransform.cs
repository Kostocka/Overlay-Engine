using Avalonia;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Rendering;

public sealed class CanvasTransform
{
    private readonly CanvasViewModel _canvas;

    public CanvasTransform(CanvasViewModel canvas)
    {
        _canvas = canvas;
    }

    public Point SceneToScreen(double x, double y)
    {
        var vp = _canvas.Viewport;
        return new Point(
            x * vp.Zoom + vp.OffsetX,
            y * vp.Zoom + vp.OffsetY);
    }

    public Point ScreenToScene(double x, double y)
    {
        var vp = _canvas.Viewport;
        return new Point(
            (x - vp.OffsetX) / vp.Zoom,
            (y - vp.OffsetY) / vp.Zoom);
    }

    public Rect SceneToScreen(Rect rect)
    {
        var topLeft = SceneToScreen(rect.X, rect.Y);

        return new Rect(
            topLeft.X,
            topLeft.Y,
            rect.Width * _canvas.Viewport.Zoom,
            rect.Height * _canvas.Viewport.Zoom);
    }
}