using OverlayEngine.Domain.Models;

namespace OverlayEngine.Application.Commands;

public sealed class ClearSelectionCommand : ICommand
{
    private readonly OverlaySession _session;

    private Guid? _previousSelected;

    public ClearSelectionCommand(OverlaySession session)
    {
        _session = session;
    }

    public void Execute()
    {
        _previousSelected = _session.SelectedWidgetId;

        _session.ClearSelection();
    }

    public void Undo()
    {
        if (_previousSelected == null)
            return;

        _session.SelectWidget(_previousSelected.Value);
    }
}