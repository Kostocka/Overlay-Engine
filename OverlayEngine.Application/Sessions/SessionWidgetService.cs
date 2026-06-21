using OverlayEngine.Application.Widgets;
using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Sessions;

public sealed class SessionWidgetService
{
    private readonly IWidgetFactory _widgetFactory;

    public SessionWidgetService(IWidgetFactory widgetFactory)
    {
        _widgetFactory = widgetFactory;
    }

    public Widget CreateWidget(WidgetDefinitionId definitionId)
    {
        return _widgetFactory.Create(definitionId);
    }
}