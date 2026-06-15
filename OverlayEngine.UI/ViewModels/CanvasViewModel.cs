using System;
using System.Collections.Generic;

namespace OverlayEngine.UI.ViewModels;

public sealed class CanvasViewModel
{
    public List<WidgetViewModel> Widgets { get; private set; } = [];

    public event Action? Changed;

    public double SceneWidth { get; set; }

    public double SceneHeight { get; set; }

    public ViewportViewModel Viewport { get; } = new();

    public void Replace(List<WidgetViewModel> widgets)
    {
        Widgets = widgets;
        Changed?.Invoke();
    }
}