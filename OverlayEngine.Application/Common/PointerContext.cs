namespace OverlayEngine.Application.Common;

public sealed class PointerContext
{
    public Vector2D Position { get; init; }
    public PointerButton Button { get; init; } = PointerButton.None;
}