using OverlayEngine.Domain.Overlay;
using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Domain.Models;

public sealed class OverlaySession
{
    private readonly List<Widget> _widgets;

    public IReadOnlyCollection<Widget> Widgets => _widgets;

    public OverlayMode Mode { get; private set; }

    public bool IsDirty { get; private set; }

    public Guid? SelectedWidgetId { get; private set; }

    public event Action<Widget>? WidgetAdded;
    public event Action<Guid>? WidgetRemoved;
    public event Action<Widget>? WidgetChanged;
    public event Action<Guid?>? SelectionChanged;

    public OverlaySession(OverlayProfile profile)
    {
        _widgets = profile.Widgets.Select(CloneWidget).ToList();
        Mode = OverlayMode.View;
        IsDirty = false;
    }

    public void EnterEditMode() => Mode = OverlayMode.Edit;

    public void EnterViewMode() => Mode = OverlayMode.View;

    public void MarkSaved() => IsDirty = false;

    private void MarkDirty() => IsDirty = true;

    public Widget? Get(Guid id) => _widgets.FirstOrDefault(x => x.Id == id);

    public Widget? GetSelected()
    {
        return SelectedWidgetId == null ? null : Get(SelectedWidgetId.Value);
    }

    public void SelectWidget(Guid widgetId)
    {
        if (_widgets.All(x => x.Id != widgetId))
            throw new InvalidOperationException($"Widget {widgetId} not found");

        SelectedWidgetId = widgetId;

        SelectionChanged?.Invoke(widgetId);
    }

    public void ClearSelection()
    {
        SelectedWidgetId = null;

        SelectionChanged?.Invoke(null);
    }

    private void EnsureEditMode()
    {
        if (Mode != OverlayMode.Edit)
            throw new InvalidOperationException("Session is not in Edit mode");
    }

    public void AddWidget(Widget widget)
    {
        EnsureEditMode();
        _widgets.Add(widget);

        MarkDirty();

        WidgetAdded?.Invoke(widget);
    }

    public void RemoveWidget(Guid id)
    {
        EnsureEditMode();

        var removed = _widgets.RemoveAll(x => x.Id == id);

        if (removed == 0)
            return;

        if (SelectedWidgetId == id)
        {
            SelectedWidgetId = null;
            SelectionChanged?.Invoke(null);
        }

        MarkDirty();

        WidgetRemoved?.Invoke(id);
    }

    public void NotifyWidgetChanged(Widget widget)
    {
        EnsureEditMode();

        MarkDirty();

        WidgetChanged?.Invoke(widget);
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