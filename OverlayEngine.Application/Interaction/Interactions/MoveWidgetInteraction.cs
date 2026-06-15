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
        editor.Select(_widgetId);
        var widget = editor.Session.Get(_widgetId) ?? throw new InvalidOperationException();

        _startMouse = context.Position;

        _startX = widget.Position.X;
        _startY = widget.Position.Y;
    }

    public void Update(PointerContext context, OverlayEditor editor)
    {
        var widget = editor.Session.Get(_widgetId) ?? throw new InvalidOperationException();

        var dx = context.Position.X - _startMouse.X;
        var dy = context.Position.Y - _startMouse.Y;

        var x = _startX + dx;
        var y = _startY + dy;

        if (x < 0)
            x = 0;

        if (y < 0)
            y = 0;

        var maxX = editor.Session.Width - widget.Size.Width;

        var maxY = editor.Session.Height - widget.Size.Height;

        if (x > maxX)
            x = maxX;

        if (y > maxY)
            y = maxY;

        editor.Move(_widgetId, x, y);
    }

    public void End(PointerContext context, OverlayEditor editor) {}
}