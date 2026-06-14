using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Domain.Events;

public sealed record WidgetAddedEvent(Widget Widget) : SessionEvent;