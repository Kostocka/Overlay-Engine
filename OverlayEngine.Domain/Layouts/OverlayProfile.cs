using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Domain.Layouts;

public sealed class OverlayProfile
{
    public string Name { get; }

    private readonly List<Widget> _widgets = [];

    public IReadOnlyCollection<Widget> Widgets => _widgets;

    public OverlayProfile(string name)
    {
        Name = name;
    }

    public void AddWidget(Widget widget)
    {
        _widgets.Add(widget);
    }

    public void RemoveWidget(Guid widgetId)
    {
        var widget = _widgets.FirstOrDefault(x => x.Id == widgetId);

        if (widget != null)
        {
            _widgets.Remove(widget);
        }
    }
}