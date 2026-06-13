namespace OverlayEngine.Domain.Overlay;

public class OverlayState
{
    public OverlayMode Mode { get; private set; } = OverlayMode.View;

    public event Action? ModeChanged;

    public void EnterEditMode()
    {
        Mode = OverlayMode.Edit;
        ModeChanged?.Invoke();
    }

    public void EnterViewMode()
    {
        Mode = OverlayMode.View;
        ModeChanged?.Invoke();
    }
}