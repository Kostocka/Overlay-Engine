using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Widgets;

public sealed class WidgetFactory : IWidgetFactory
{
    private readonly WidgetCatalog _catalog;

    public WidgetFactory(WidgetCatalog catalog)
    {
        _catalog = catalog;
    }

    public Widget Create(WidgetDefinitionId definitionId)
    {
        return _catalog.CreateDefault(definitionId);
    }
}