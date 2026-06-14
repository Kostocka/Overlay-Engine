using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;

namespace OverlayEngine.Application.Interaction.Interactions;

public sealed class MoveWidgetInteraction : IWidgetInteraction
{
    private readonly Guid _widgetId;

    private Vector2D _startMouse;

    private double _startX;
    private double _startY;

    public MoveWidgetInteraction(Guid widgetId)
    {
        _widgetId = widgetId;
    }

    public void Begin(PointerContext context, OverlayEditor editor)
    {
        var widget = editor.Session.Get(_widgetId) ?? throw new InvalidOperationException();

        _startMouse = context.Position;

        _startX = widget.Position.X;
        _startY = widget.Position.Y;
    }

    public void Update(PointerContext context, OverlayEditor editor)
    {
        var dx = context.Position.X - _startMouse.X;
        var dy = context.Position.Y - _startMouse.Y;

        editor.Move(_widgetId, _startX + dx, _startY + dy);
    }

    public void End(PointerContext context, OverlayEditor editor) {}
}