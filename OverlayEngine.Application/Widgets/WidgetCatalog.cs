using OverlayEngine.Application.Widgets.Definitions;
using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Widgets;

public sealed class WidgetCatalog
{
    private readonly IReadOnlyDictionary<string, IWidgetDefinition> _definitions;

    public IReadOnlyCollection<IWidgetDefinition> All => _definitions.Values.ToArray();

    public WidgetCatalog(IEnumerable<IWidgetDefinition> definitions)
    {
        _definitions = definitions.ToDictionary(x => x.Id.Value);
    }

    public Widget CreateDefault(WidgetDefinitionId id)
    {
        if (!_definitions.TryGetValue(id.Value, out var definition))
        {
            throw new NotSupportedException($"No widget definition for id: {id}");
        }

        return definition.CreateDefault();
    }
}