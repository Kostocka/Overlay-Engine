using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;
using OverlayEngine.Application.Interaction.Interactions;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Interaction.Regions;

public sealed class ResizeRegion : IHitRegion
{
    private readonly int _horizontal;
    private readonly int _vertical;

    private ResizeRegion(int horizontal, int vertical)
    {
        _horizontal = horizontal;
        _vertical = vertical;
    }

    public static ResizeRegion TopLeft() => new(-1, -1);
    public static ResizeRegion Top() => new(0, -1);
    public static ResizeRegion TopRight() => new(1, -1);

    public static ResizeRegion Right() => new(1, 0);

    public static ResizeRegion BottomRight() => new(1, 1);
    public static ResizeRegion Bottom() => new(0, 1);
    public static ResizeRegion BottomLeft() => new(-1, 1);

    public static ResizeRegion Left() => new(-1, 0);

    public bool HitTest(Widget widget, Vector2D point)
    {
        var t = EditorInteractionSettings.ResizeBorderThickness;

        var left = widget.Position.X;
        var top = widget.Position.Y;
        var right = left + widget.Size.Width;
        var bottom = top + widget.Size.Height;

        var onLeft = point.X >= left && point.X <= left + t;
        var onRight = point.X >= right - t && point.X <= right;
        var onTop = point.Y >= top && point.Y <= top + t;
        var onBottom = point.Y >= bottom - t && point.Y <= bottom;

        var insideX = point.X > left + t && point.X < right - t;
        var insideY = point.Y > top + t && point.Y < bottom - t;

        if (_horizontal < 0 && _vertical < 0) return onLeft && onTop;
        if (_horizontal == 0 && _vertical < 0) return insideX && onTop;
        if (_horizontal > 0 && _vertical < 0) return onRight && onTop;

        if (_horizontal > 0 && _vertical == 0) return onRight && insideY;

        if (_horizontal > 0 && _vertical > 0) return onRight && onBottom;
        if (_horizontal == 0 && _vertical > 0) return insideX && onBottom;
        if (_horizontal < 0 && _vertical > 0) return onLeft && onBottom;

        if (_horizontal < 0 && _vertical == 0) return onLeft && insideY;

        return false;
    }

    public IWidgetInteraction CreateInteraction(Guid widgetId)
    {
        return new ResizeWidgetInteraction(widgetId, _horizontal, _vertical);
    }
}