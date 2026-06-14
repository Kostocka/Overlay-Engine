using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;

namespace OverlayEngine.Application.Interaction.Interactions;

public sealed class ResizeWidgetInteraction : IWidgetInteraction
{
    private readonly Guid _widgetId;

    private readonly int _horizontal;
    private readonly int _vertical;

    private Vector2D _startMouse;

    private double _startX;
    private double _startY;

    private double _startWidth;
    private double _startHeight;

    public ResizeWidgetInteraction(Guid widgetId, int horizontal, int vertical)
    {
        _widgetId = widgetId;
        _horizontal = horizontal;
        _vertical = vertical;
    }

    public void Begin(PointerContext context, OverlayEditor editor)
    {
        var widget = editor.Session.Get(_widgetId) ?? throw new InvalidOperationException("Widget not found");

        _startMouse = context.Position;

        _startX = widget.Position.X;
        _startY = widget.Position.Y;

        _startWidth = widget.Size.Width;
        _startHeight = widget.Size.Height;
    }

    public void Update(PointerContext context, OverlayEditor editor)
    {
        var dx = context.Position.X - _startMouse.X;
        var dy = context.Position.Y - _startMouse.Y;

        var newX = _startX;
        var newY = _startY;

        var newWidth = _startWidth;
        var newHeight = _startHeight;

        if (_horizontal > 0)
        {
            newWidth += dx;
        }
        else if (_horizontal < 0)
        {
            newX += dx;
            newWidth -= dx;
        }

        if (_vertical > 0)
        {
            newHeight += dy;
        }
        else if (_vertical < 0)
        {
            newY += dy;
            newHeight -= dy;
        }

        if (newWidth < EditorInteractionSettings.MinWidgetSize)
        {
            if (_horizontal < 0)
            {
                newX = _startX + (_startWidth - EditorInteractionSettings.MinWidgetSize);
            }

            newWidth = EditorInteractionSettings.MinWidgetSize;
        }

        if (newHeight < EditorInteractionSettings.MinWidgetSize)
        {
            if (_vertical < 0)
            {
                newY = _startY + (_startHeight - EditorInteractionSettings.MinWidgetSize);
            }

            newHeight = EditorInteractionSettings.MinWidgetSize;
        }

        if (newX != _startX || newY != _startY)
        {
            editor.Move(_widgetId, newX, newY);
        }

        editor.Resize(_widgetId, newWidth, newHeight);
    }

    public void End(PointerContext context, OverlayEditor editor) { }
}