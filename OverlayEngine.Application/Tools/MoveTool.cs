using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;

namespace OverlayEngine.Application.Tools;

public sealed class MoveTool : ITool
{
    private readonly OverlayEditor _editor;

    private Guid? _activeWidget;
    private Vector2D _startMouse;
    private double _startX;
    private double _startY;
    private bool _dragging;

    public MoveTool(OverlayEditor editor)
    {
        _editor = editor;
    }

    public void OnPointerDown(PointerContext context)
    {
        if (context.WidgetId == null)
            return;

        _activeWidget = context.WidgetId;
        _dragging = true;

        _startMouse = context.Position;

        var widget = _editor.Session.Get(context.WidgetId.Value);
        if (widget == null)
            return;

        _startX = widget.Position.X;
        _startY = widget.Position.Y;

        _editor.Select(context.WidgetId.Value);
    }

    public void OnPointerMove(PointerContext context)
    {
        if (!_dragging || _activeWidget == null)
            return;

        var dx = context.Position.X - _startMouse.X;
        var dy = context.Position.Y - _startMouse.Y;

        var newX = _startX + dx;
        var newY = _startY + dy;

        _editor.Move(_activeWidget.Value, newX, newY);
    }

    public void OnPointerUp(PointerContext context)
    {
        _dragging = false;
        _activeWidget = null;
    }
}