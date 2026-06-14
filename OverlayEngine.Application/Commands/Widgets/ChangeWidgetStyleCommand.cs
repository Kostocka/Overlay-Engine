using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.ValueObjects;

namespace OverlayEngine.Application.Commands.Widgets;

public sealed class ChangeWidgetStyleCommand : ICommand
{
    private readonly OverlaySession _session;
    private readonly Guid _widgetId;

    private readonly WidgetStyle _newStyle;

    private WidgetStyle? _oldStyle;

    public ChangeWidgetStyleCommand(OverlaySession session, Guid widgetId, WidgetStyle newStyle)
    {
        _session = session;
        _widgetId = widgetId;
        _newStyle = newStyle;
    }

    public void Execute()
    {
        var widget = _session.Get(_widgetId) ?? throw new InvalidOperationException();

        _oldStyle = widget.Style;

        widget.ChangeStyle(_newStyle);

        _session.UpdateWidget(widget);
    }

    public void Undo()
    {
        if (_oldStyle == null)
            return;

        var widget = _session.Get(_widgetId) ?? throw new InvalidOperationException();

        widget.ChangeStyle(_oldStyle);

        _session.UpdateWidget(widget);
    }
}