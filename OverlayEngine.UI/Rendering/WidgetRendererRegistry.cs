using System.Collections.Generic;
using System.Linq;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Rendering;

public sealed class WidgetRendererRegistry
{
    private readonly List<IWidgetRenderer> _renderers;

    public WidgetRendererRegistry()
    {
        _renderers = [new TextWidgetRenderer()];
    }

    public IWidgetRenderer Get(WidgetViewModel widget)
    {
        return _renderers.First(x => x.CanRender(widget));
    }
}