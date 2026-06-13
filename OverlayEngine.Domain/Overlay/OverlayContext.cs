using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Domain.Overlay;

public sealed class OverlayContext
{
    private readonly List<Widget> _widgets = new();

    public IReadOnlyList<Widget> Widgets => _widgets;

    public void SetWidgets(IEnumerable<Widget> widgets)
    {
        _widgets.Clear();
        _widgets.AddRange(widgets);
    }

    public void RemoveWidget(Guid id)
    {
        var widget = _widgets.FirstOrDefault(x => x.Id == id);
        if (widget != null)
            _widgets.Remove(widget);
    }

    public void AddWidget(Widget widget)
    {
        _widgets.Add(widget);
    }
}