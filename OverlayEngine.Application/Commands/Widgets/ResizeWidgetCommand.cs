using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.ValueObjects;

namespace OverlayEngine.Application.Commands.Widgets;

public sealed class ResizeWidgetCommand : ICommand
{
    private readonly OverlaySession _session;
    private readonly Guid _widgetId;

    private readonly WidgetSize _newSize;

    private WidgetSize? _oldSize;

    public ResizeWidgetCommand( OverlaySession session, Guid widgetId, WidgetSize newSize)
    {
        _session = session;
        _widgetId = widgetId;
        _newSize = newSize;
    }

    public void Execute()
    {
        var widget = _session.Get(_widgetId) ?? throw new InvalidOperationException();

        _oldSize = widget.Size;

        widget.Resize(_newSize);

        _session.NotifyWidgetChanged(widget);
    }

    public void Undo()
    {
        if (_oldSize == null)
            return;

        var widget = _session.Get(_widgetId) ?? throw new InvalidOperationException();

        widget.Resize(_oldSize);

        _session.NotifyWidgetChanged(widget);
    }
}