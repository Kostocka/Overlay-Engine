namespace OverlayEngine.Domain.Events;

public sealed record WidgetRemovedEvent(Guid WidgetId) : SessionEvent;