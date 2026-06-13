using System;
using Avalonia.Controls;
using OverlayEngine.Domain.Widgets;
using OverlayEngine.Domain.Overlay;

namespace OverlayEngine.App.Controls;

public class WidgetChrome : ContentControl
{
    public Widget Widget { get; }
    public OverlayState State { get; }

    private readonly Grid _root = new();

    public event Action<Guid>? RemoveRequested;

    public WidgetChrome(Widget widget, OverlayState state, Control content)
    {
        Widget = widget;
        State = state;

        _root.Children.Add(content);
        Content = _root;
    }

    public void AddOverlay(Control control)
    {
        _root.Children.Add(control);
    }

    public void RequestRemove()
    {
        RemoveRequested?.Invoke(Widget.Id);
    }
}