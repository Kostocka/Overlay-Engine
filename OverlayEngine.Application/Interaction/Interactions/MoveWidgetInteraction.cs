using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;

namespace OverlayEngine.Application.Interaction.Interactions;

public sealed class MoveWidgetInteraction : IWidgetInteraction
{
    private readonly Guid _widgetId;

    private Vector2D _startMouse;

    private double _startX;
    private double _startY;
    private readonly EditorBoundsService _bounds;

    public MoveWidgetInteraction(Guid widgetId, EditorBoundsService editorBoundsService)
    {
        _widgetId = widgetId;
        _bounds = editorBoundsService;
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

        var position = _bounds.ClampPosition(editor.Session, x, y, widget.Size.Width, widget.Size.Height);

        editor.Move(_widgetId, position.X, position.Y);
    }

    public void End(PointerContext context, OverlayEditor editor) {}
}