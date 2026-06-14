using OverlayEngine.Application.Common;

namespace OverlayEngine.Application.Interaction;

public interface IWidgetHitTestService
{
    HitResult? HitTest(Vector2D point);
}