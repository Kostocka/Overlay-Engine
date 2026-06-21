using OverlayEngine.Application.Sessions;
using OverlayEngine.Application.Widgets;
using OverlayEngine.Application.Widgets.Definitions;

namespace OverlayEngine.UI.Composition;

public sealed record WidgetModuleResult(
    WidgetCatalog Catalog,
    IWidgetFactory Factory,
    SessionWidgetService SessionWidgets);

public static class WidgetModule
{
    public static WidgetModuleResult Build()
    {
        var definitions = new IWidgetDefinition[]
        {
            new TextWidgetDefinition(),
        };

        var catalog = new WidgetCatalog(definitions);
        var factory = new WidgetFactory(catalog);
        var sessionWidgets = new SessionWidgetService(factory);

        return new WidgetModuleResult(catalog, factory, sessionWidgets);
    }
}