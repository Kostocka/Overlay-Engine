using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;
using OverlayEngine.Application.Interaction.Interactions;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Interaction.Regions;

public sealed class BodyRegion : IHitRegion
{
    public static BodyRegion Instance { get; } = new();

    private BodyRegion() {}

    public bool HitTest(Widget widget, Vector2D point)
    {
        var t = EditorInteractionSettings.ResizeBorderThickness;

        var left = widget.Position.X + t;
        var top = widget.Position.Y + t;
        var right = widget.Position.X + widget.Size.Width - t;
        var bottom = widget.Position.Y + widget.Size.Height - t;

        if (right < left || bottom < top)
        {
            return point.X >= widget.Position.X
                   && point.X <= widget.Position.X + widget.Size.Width
                   && point.Y >= widget.Position.Y
                   && point.Y <= widget.Position.Y + widget.Size.Height;
        }

        return point.X >= left
               && point.X <= right
               && point.Y >= top
               && point.Y <= bottom;
    }

    public IWidgetInteraction CreateInteraction(OverlayEditor editor, Guid widgetId)
    {
        return new MoveWidgetInteraction(editor, widgetId);
    }
}