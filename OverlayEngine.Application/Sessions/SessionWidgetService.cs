using OverlayEngine.Application.Widgets;
using OverlayEngine.Application.Widgets.Templates;
using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Sessions;

public sealed class SessionWidgetService
{
    private readonly OverlaySessionService _sessionService;
    private readonly IWidgetFactory _widgetFactory;

    public SessionWidgetService(OverlaySessionService sessionService, IWidgetFactory widgetFactory)
    {
        _sessionService = sessionService;
        _widgetFactory = widgetFactory;
    }

    private OverlaySession Session => _sessionService.GetRequiredSession();

    public Widget Add(WidgetTemplate template)
    {
        var widget = _widgetFactory.Create(template);
        Session.AddWidget(widget);
        return widget;
    }

    public void Remove(Guid widgetId)
    {
        Session.RemoveWidget(widgetId);
    }

    public void Move(Guid widgetId, double x, double y)
    {
        var widget = Session.Get(widgetId);

        widget.MoveTo(x, y);

        Session.NotifyWidgetChanged(widget);
    }

    public void Resize(Guid widgetId, double width, double height)
    {
        var widget = Session.Get(widgetId);

        widget.Resize(width, height);

        Session.NotifyWidgetChanged(widget);
    }

    public void ChangeStyle(Guid widgetId, Domain.ValueObjects.WidgetStyle style)
    {
        var widget = Session.Get(widgetId);

        widget.ChangeStyle(style);

        Session.NotifyWidgetChanged(widget);
    }
}