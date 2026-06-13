using OverlayEngine.Domain.Overlay;
using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Domain.Models;

public sealed class OverlaySession
{
    private readonly List<Widget> _widgets;

    public IReadOnlyCollection<Widget> Widgets => _widgets;

    public OverlayMode Mode { get; private set; }

    public OverlaySession(OverlayProfile profile)
    {
        _widgets = profile.Widgets.Select(CloneWidget).ToList();
        Mode = OverlayMode.View;
    }

    public void EnterEditMode() => Mode = OverlayMode.Edit;

    public void EnterViewMode() => Mode = OverlayMode.View;

    private void EnsureEditMode()
    {
        if (Mode != OverlayMode.Edit)
            throw new InvalidOperationException("Session is not in Edit mode");
    }

    public void AddWidget(Widget widget)
    {
        EnsureEditMode();
        _widgets.Add(widget);
    }

    public void RemoveWidget(Guid id)
    {
        EnsureEditMode();
        _widgets.RemoveAll(x => x.Id == id);
    }

    public Widget? Get(Guid id)
        => _widgets.FirstOrDefault(x => x.Id == id);

    public void MoveWidget(Guid id, double x, double y)
    {
        EnsureEditMode();

        var widget = Get(id)
            ?? throw new InvalidOperationException($"Widget {id} not found");

        widget.MoveTo(x, y);
    }

    public void ResizeWidget(Guid id, double w, double h)
    {
        EnsureEditMode();

        var widget = Get(id)
            ?? throw new InvalidOperationException($"Widget {id} not found");

        widget.Resize(w, h);
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