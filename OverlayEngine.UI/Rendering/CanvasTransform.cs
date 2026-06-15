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

    public Point SceneToScreen(Point p)
    {
        var vp = _canvas.Viewport;
        return new Point(
            p.X * vp.Zoom + vp.OffsetX,
            p.Y * vp.Zoom + vp.OffsetY);
    }

    public Point ScreenToScene(Point p)
    {
        var vp = _canvas.Viewport;
        return new Point(
            (p.X - vp.OffsetX) / vp.Zoom,
            (p.Y - vp.OffsetY) / vp.Zoom);
    }

    public Rect SceneToScreen(Rect r)
    {
        var topLeft = SceneToScreen(new Point(r.X, r.Y));
        var vp = _canvas.Viewport;

        return new Rect(
            topLeft.X,
            topLeft.Y,
            r.Width * vp.Zoom,
            r.Height * vp.Zoom);
    }
}