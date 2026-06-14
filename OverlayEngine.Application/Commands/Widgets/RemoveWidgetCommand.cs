using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Commands.Widgets;

public sealed class RemoveWidgetCommand : ICommand
{
    private readonly OverlaySession _session;
    private readonly Guid _widgetId;

    private Widget? _removedWidget;

    public RemoveWidgetCommand(OverlaySession session, Guid widgetId)
    {
        _session = session;
        _widgetId = widgetId;
    }

    public void Execute()
    {
        _removedWidget = _session.Get(_widgetId);

        if (_removedWidget == null)
            return;

        _session.RemoveWidget(_widgetId);
    }

    public void Undo()
    {
        if (_removedWidget == null)
            return;

        _session.AddWidget(_removedWidget);
    }
}