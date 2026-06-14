using OverlayEngine.Application.Common;

namespace OverlayEngine.Application.Tools;

public sealed class PointerContext
{
    public Guid? WidgetId { get; init; }
    public Vector2D Position { get; init; }
    public bool IsLeftButton { get; init; }
}