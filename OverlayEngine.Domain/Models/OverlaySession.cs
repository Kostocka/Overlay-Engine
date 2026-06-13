using OverlayEngine.Domain.Overlay;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Domain.Models;

public sealed class OverlaySession
{
    private readonly List<Widget> _widgets;

    public IReadOnlyCollection<Widget> Widgets => _widgets;

    public OverlayMode Mode { get; private set; }

    public Widget? SelectedWidget { get; private set; }

    public OverlaySession(OverlayProfile profile)
    {
        _widgets = profile.Widgets.Select(CloneWidget).ToList();

        Mode = OverlayMode.View;
    }

    public void EnterEditMode()
    {
        Mode = OverlayMode.Edit;
    }

    public void EnterViewMode()
    {
        Mode = OverlayMode.View;
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

    public void SelectWidget(Guid widgetId)
    {
        SelectedWidget = _widgets.FirstOrDefault(x => x.Id == widgetId);
    }

    public void MoveWidget(Guid widgetId, double x, double y)
    {
        var widget = _widgets.FirstOrDefault(x => x.Id == widgetId);

        widget?.MoveTo(x, y);
    }

    public void ResizeWidget( Guid widgetId, double width,double height)
    {
        var widget = _widgets.FirstOrDefault(x => x.Id == widgetId);

        widget?.Resize(width, height);
    }

    private static Widget CloneWidget(Widget widget)
    {
        return new Widget(
            widget.Id,
            widget.Name,
            new WidgetPosition(widget.Position.X, widget.Position.Y),
            new WidgetSize(widget.Size.Width, widget.Size.Height),
            widget.Style,
            widget.Data);
    }
}