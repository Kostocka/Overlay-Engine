using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;
using OverlayEngine.Application.Interaction.Regions;
using OverlayEngine.Application.Sessions;

namespace OverlayEngine.Application.Interaction;

public sealed class WidgetHitTestService : IWidgetHitTestService
{
    private readonly OverlaySessionService _sessionService;
    private readonly IHitRegion[] _regions;

    public WidgetHitTestService(OverlaySessionService sessionService, EditorBoundsService bounds)
    {
        _sessionService = sessionService;

        _regions =
        [
            ResizeRegion.TopLeft(bounds),
            ResizeRegion.Top(bounds),
            ResizeRegion.TopRight(bounds),
            ResizeRegion.Right(bounds),
            ResizeRegion.BottomRight(bounds),
            ResizeRegion.Bottom(bounds),
            ResizeRegion.BottomLeft(bounds),
            ResizeRegion.Left(bounds),
            new BodyRegion(bounds)
        ];
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