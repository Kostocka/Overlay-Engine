using OverlayEngine.Domain.Overlay;

namespace OverlayEngine.Domain.Events;

public sealed record SessionModeChangedEvent(OverlayMode Mode) : SessionEvent;