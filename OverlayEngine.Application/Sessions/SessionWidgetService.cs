using OverlayEngine.Application.Widgets;
using OverlayEngine.Application.Widgets.Templates;
using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Sessions;

public sealed class SessionWidgetService
{
    private readonly OverlaySessionService _sessionService;
    private readonly IWidgetFactory _widgetFactory;

    public SessionWidgetService( OverlaySessionService sessionService, IWidgetFactory widgetFactory)
    {
        _sessionService = sessionService;
        _widgetFactory = widgetFactory;
    }

    private OverlaySession Session =>
        _sessionService.CurrentSession ?? throw new InvalidOperationException("No active session");

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
        Session.MoveWidget(widgetId, x, y);
    }

    public void Resize(Guid widgetId, double w, double h)
    {
        Session.ResizeWidget(widgetId, w, h);
    }
}