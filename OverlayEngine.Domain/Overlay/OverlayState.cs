namespace OverlayEngine.Domain.Overlay;

public sealed class OverlayState
{
    public OverlayMode Mode { get; private set; }

    public OverlayState()
    {
        Mode = OverlayMode.Edit;
    }

    public void EnterEditMode()
    {
        Mode = OverlayMode.Edit;
    }

    public void EnterViewMode()
    {
        Mode = OverlayMode.View;
    }
}