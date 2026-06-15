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

    private readonly EditorBoundsService _bounds;

    public ResizeWidgetInteraction(Guid widgetId, int horizontal, int vertical, EditorBoundsService editorBoundsService)
    {
        _widgetId = widgetId;
        _horizontal = horizontal;
        _vertical = vertical;
        _bounds = editorBoundsService;
    }

    public void Begin(PointerContext context, OverlayEditor editor)
    {
        editor.Select(_widgetId);
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

        var result = _bounds.ClampResize(editor.Session, _startX, _startY, _startWidth, _startHeight, dx, dy, _horizontal, _vertical);

        editor.Move(_widgetId, result.X, result.Y);
        editor.Resize(_widgetId, result.Width, result.Height);
    }

    public void End(PointerContext context, OverlayEditor editor) { }
}