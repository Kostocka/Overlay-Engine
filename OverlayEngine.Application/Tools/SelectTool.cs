using OverlayEngine.Application.Common;
using OverlayEngine.Application.Interaction;

namespace OverlayEngine.Application.Tools;

public sealed class SelectTool : ITool
{
    private readonly IWidgetHitTestService _hitTest;

    public SelectTool(IWidgetHitTestService hitTest)
    {
        _hitTest = hitTest;
    }

    public IWidgetInteraction? CreateInteraction(PointerContext context)
    {
        var hit = _hitTest.HitTest(context.Position);

        if (hit == null)
            return null;

        return hit.Region.CreateInteraction(hit.WidgetId);
    }
}