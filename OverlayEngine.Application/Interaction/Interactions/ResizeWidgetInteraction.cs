using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;

namespace OverlayEngine.Application.Interaction.Interactions;

public sealed class ResizeWidgetInteraction : IWidgetInteraction
{
    private readonly OverlayEditor _editor;
    private readonly Guid _widgetId;

    private readonly int _horizontal;
    private readonly int _vertical;

    private Vector2D _startMouse;
    private double _startX;
    private double _startY;
    private double _startWidth;
    private double _startHeight;
    private bool _active;

    public ResizeWidgetInteraction(OverlayEditor editor, Guid widgetId, int horizontal, int vertical)
    {
        _editor = editor;
        _widgetId = widgetId;
        _horizontal = horizontal;
        _vertical = vertical;
    }

    public void Begin(PointerContext context)
    {
        var widget = _editor.Session.Get(_widgetId) ?? throw new InvalidOperationException("Widget not found");

        _startMouse = context.Position;
        _startX = widget.Position.X;
        _startY = widget.Position.Y;
        _startWidth = widget.Size.Width;
        _startHeight = widget.Size.Height;

        _active = true;
    }

    public void Update(PointerContext context)
    {
        if (!_active)
            return;

        var dx = context.Position.X - _startMouse.X;
        var dy = context.Position.Y - _startMouse.Y;

        var newX = _startX;
        var newY = _startY;
        var newWidth = _startWidth;
        var newHeight = _startHeight;

        if (_horizontal > 0)
        {
            newWidth = _startWidth + dx;
        }
        else if (_horizontal < 0)
        {
            newX = _startX + dx;
            newWidth = _startWidth - dx;
        }

        if (_vertical > 0)
        {
            newHeight = _startHeight + dy;
        }
        else if (_vertical < 0)
        {
            newY = _startY + dy;
            newHeight = _startHeight - dy;
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
            _editor.Move(_widgetId, newX, newY);
        }

        _editor.Resize(_widgetId, newWidth, newHeight);
    }

    public void End(PointerContext context)
    {
        _active = false;
    }
}