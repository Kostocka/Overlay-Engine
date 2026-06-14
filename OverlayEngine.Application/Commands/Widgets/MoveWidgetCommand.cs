using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.ValueObjects;

namespace OverlayEngine.Application.Commands.Widgets;

public sealed class MoveWidgetCommand : ICommand
{
    private readonly OverlaySession _session;
    private readonly Guid _widgetId;

    private readonly WidgetPosition _newPosition;

    private WidgetPosition? _oldPosition;

    public MoveWidgetCommand(OverlaySession session, Guid widgetId, WidgetPosition newPosition)
    {
        _session = session;
        _widgetId = widgetId;
        _newPosition = newPosition;
    }

    public void Execute()
    {
        var widget = _session.Get(_widgetId) ?? throw new InvalidOperationException();

        _oldPosition = widget.Position;

        widget.MoveTo(_newPosition);

        _session.NotifyWidgetChanged(widget);
    }

    public void Undo()
    {
        if (_oldPosition == null)
            return;

        var widget = _session.Get(_widgetId) ?? throw new InvalidOperationException();

        widget.MoveTo(_oldPosition);

        _session.NotifyWidgetChanged(widget);
    }
}