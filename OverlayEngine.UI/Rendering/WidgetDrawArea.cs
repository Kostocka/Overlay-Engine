using Avalonia;

namespace OverlayEngine.UI.Rendering;

public sealed record WidgetDrawArea(double X, double Y, double Width, double Height)
{
    public Rect ToRect() => new Rect(X, Y, Width, Height);
}