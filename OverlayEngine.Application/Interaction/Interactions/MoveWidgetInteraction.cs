using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;

namespace OverlayEngine.Application.Interaction.Interactions;

public sealed class MoveWidgetInteraction : IWidgetInteraction
{
    private readonly OverlayEditor _editor;
    private readonly Guid _widgetId;

    private Vector2D _startMouse;
    private double _startX;
    private double _startY;
    private bool _active;

    public MoveWidgetInteraction(OverlayEditor editor, Guid widgetId)
    {
        _editor = editor;
        _widgetId = widgetId;
    }

    public void Begin(PointerContext context)
    {
        var widget = _editor.Session.Get(_widgetId) ?? throw new InvalidOperationException("Widget not found");

        _startMouse = context.Position;
        _startX = widget.Position.X;
        _startY = widget.Position.Y;

        _active = true;
    }

    public void Update(PointerContext context)
    {
        if (!_active)
            return;

        var dx = context.Position.X - _startMouse.X;
        var dy = context.Position.Y - _startMouse.Y;

        _editor.Move(_widgetId, _startX + dx, _startY + dy);
    }

    public void End(PointerContext context)
    {
        _active = false;
    }
}