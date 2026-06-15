using OverlayEngine.Domain.Events;
using OverlayEngine.Domain.Overlay;
using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Domain.Models;

public sealed class OverlaySession
{
    private readonly List<Widget> _widgets;

    public double Width { get; }

    public double Height { get; }

    public IReadOnlyCollection<Widget> Widgets => _widgets;

    public OverlayMode Mode { get; private set; }

    public bool IsDirty { get; private set; }

    public Guid? SelectedWidgetId { get; private set; }

    public event Action<SessionEvent>? SessionChanged;

    public OverlaySession(OverlayProfile profile)
    {
        Width = profile.Width;
        Height = profile.Height;
        _widgets = profile.Widgets.Select(CloneWidget).ToList();
        Mode = OverlayMode.View;
        IsDirty = false;
    }

    public void EnterEditMode()
    {
        Mode = OverlayMode.Edit;

        Publish(new SessionModeChangedEvent(Mode));
    }

    public void EnterViewMode()
    {
        Mode = OverlayMode.View;

        Publish(new SessionModeChangedEvent(Mode));
    }

    public void MarkSaved() => IsDirty = false;

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

        Publish(new SelectionChangedEvent(widgetId));
    }

    public void ClearSelection()
    {
        SelectedWidgetId = null;

        Publish(new SelectionChangedEvent(null));
    }

    public void AddWidget(Widget widget)
    {
        EnsureEditMode();

        _widgets.Add(widget);
        MarkDirty();

        Publish(new WidgetAddedEvent(widget));
    }

    public void RemoveWidget(Guid id)
    {
        EnsureEditMode();

        var widget = _widgets.FirstOrDefault(x => x.Id == id);
        if (widget == null)
            return;

        _widgets.Remove(widget);

        if (SelectedWidgetId == id)
        {
            SelectedWidgetId = null;
            Publish(new SelectionChangedEvent(null));
        }

        MarkDirty();

        Publish(new WidgetRemovedEvent(id));
    }

    public void UpdateWidget(Widget widget)
    {
        EnsureEditMode();

        MarkDirty();

        Publish(new WidgetChangedEvent(widget));
    }

    private void MarkDirty() => IsDirty = true;

    private void Publish(SessionEvent @event) => SessionChanged?.Invoke(@event);

    private void EnsureEditMode()
    {
        if (Mode != OverlayMode.Edit)
            throw new InvalidOperationException("Session is not in Edit mode");
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