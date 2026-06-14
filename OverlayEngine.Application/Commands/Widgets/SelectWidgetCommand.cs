using OverlayEngine.Domain.Models;

namespace OverlayEngine.Application.Commands;

public sealed class SelectWidgetCommand : ICommand
{
    private readonly OverlaySession _session;
    private readonly Guid _widgetId;

    private Guid? _previousSelected;

    public SelectWidgetCommand(OverlaySession session, Guid widgetId)
    {
        _session = session;
        _widgetId = widgetId;
    }

    public void Execute()
    {
        _previousSelected = _session.SelectedWidgetId;

        _session.SelectWidget(_widgetId);
    }

    public void Undo()
    {
        if (_previousSelected == null)
        {
            _session.ClearSelection();
            return;
        }

        _session.SelectWidget(_previousSelected.Value);
    }
}