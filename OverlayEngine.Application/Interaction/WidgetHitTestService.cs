using OverlayEngine.Application.Common;
using OverlayEngine.Application.Interaction.Regions;
using OverlayEngine.Application.Sessions;

namespace OverlayEngine.Application.Interaction;

public sealed class WidgetHitTestService : IWidgetHitTestService
{
    private readonly OverlaySessionService _sessionService;

    private readonly IHitRegion[] _regions =
    [
        ResizeRegion.TopLeft(),
        ResizeRegion.Top(),
        ResizeRegion.TopRight(),
        ResizeRegion.Right(),
        ResizeRegion.BottomRight(),
        ResizeRegion.Bottom(),
        ResizeRegion.BottomLeft(),
        ResizeRegion.Left(),
        BodyRegion.Instance
    ];

    public WidgetHitTestService(OverlaySessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public HitResult? HitTest(Vector2D point)
    {
        var session = _sessionService.GetRequiredSession();

        foreach (var widget in session.Widgets.Reverse())
        {
            foreach (var region in _regions)
            {
                if (region.HitTest(widget, point))
                {
                    return new HitResult(widget.Id, region);
                }
            }
        }

        return null;
    }
}