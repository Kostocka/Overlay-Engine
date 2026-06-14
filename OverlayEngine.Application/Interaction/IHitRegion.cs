using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Interaction;

public interface IHitRegion
{
    bool HitTest(Widget widget, Vector2D point);

    IWidgetInteraction CreateInteraction(Guid widgetId);
}