using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Domain.Events;

public sealed record WidgetChangedEvent(Widget Widget) : SessionEvent;