namespace OverlayEngine.Domain.Events;

public abstract record SessionEvent
{
    public DateTime OccurredAt { get; }

    protected SessionEvent()
    {
        OccurredAt = DateTime.UtcNow;
    }
}