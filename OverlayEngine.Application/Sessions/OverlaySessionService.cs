using OverlayEngine.Domain.Models;

namespace OverlayEngine.Application.Sessions;

public sealed class OverlaySessionService
{
    public OverlaySession? CurrentSession { get; private set; }

    public bool HasActiveSession => CurrentSession != null;

    public void OpenProfile(OverlayProfile profile)
    {
        CurrentSession = new OverlaySession(profile);
    }

    public void CloseSession()
    {
        CurrentSession = null;
    }
}