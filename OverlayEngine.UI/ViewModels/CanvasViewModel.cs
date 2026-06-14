using System.Collections.Generic;

namespace OverlayEngine.UI.ViewModels;

public sealed class CanvasViewModel
{
    public List<WidgetViewModel> Widgets { get; private set; } = [];

    public void Replace(List<WidgetViewModel> widgets)
    {
        Widgets = widgets;
    }
}