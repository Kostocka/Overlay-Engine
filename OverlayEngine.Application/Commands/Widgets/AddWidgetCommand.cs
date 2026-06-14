using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Commands.Widgets;

public sealed class AddWidgetCommand : ICommand
{
    private readonly OverlaySession _session;
    private readonly Widget _widget;

    public AddWidgetCommand( OverlaySession session, Widget widget)
    {
        _session = session;
        _widget = widget;
    }

    public void Execute()
    {
        _session.AddWidget(_widget);
    }

    public void Undo()
    {
        _session.RemoveWidget(_widget.Id);
    }
}