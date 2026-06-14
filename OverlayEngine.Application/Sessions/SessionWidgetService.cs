using OverlayEngine.Application.Widgets;
using OverlayEngine.Application.Widgets.Templates;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Sessions;

public sealed class SessionWidgetService
{
    private readonly IWidgetFactory _widgetFactory;

    public SessionWidgetService(IWidgetFactory widgetFactory)
    {
        _widgetFactory = widgetFactory;
    }

    public Widget CreateWidget(WidgetTemplate template)
    {
        return _widgetFactory.Create(template);
    }
}