namespace OverlayEngine.Domain.Events;

public sealed record SelectionChangedEvent(Guid? WidgetId) : SessionEvent;