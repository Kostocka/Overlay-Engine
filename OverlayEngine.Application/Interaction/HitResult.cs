namespace OverlayEngine.Application.Interaction;

public sealed record HitResult(Guid WidgetId, IHitRegion Region);