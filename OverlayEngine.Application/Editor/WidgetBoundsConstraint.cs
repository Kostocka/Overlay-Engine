using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Editor;

public sealed class WidgetBoundsConstraint
{
    private readonly EditorBounds _bounds;

    public WidgetBoundsConstraint(EditorBounds bounds)
    {
        _bounds = bounds;
    }

    public (double X, double Y) ClampMove(Widget widget, double targetX, double targetY)
    {
        var maxX = _bounds.Width - widget.Size.Width;
        var maxY = _bounds.Height - widget.Size.Height;

        var x = Math.Clamp(targetX, 0, maxX);
        var y = Math.Clamp(targetY, 0, maxY);

        return (x, y);
    }
}