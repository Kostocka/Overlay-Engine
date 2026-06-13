using OverlayEngine.Application.Widgets.Templates;

namespace OverlayEngine.Application.Widgets;

public sealed class WidgetCatalog
{
    private readonly List<WidgetTemplate> _templates = new();

    public void Register(WidgetTemplate template)
    {
        _templates.Add(template);
    }

    public IReadOnlyList<WidgetTemplate> GetAll() => _templates;
}