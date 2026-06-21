using System;
using System.Collections.Generic;
using System.Linq;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Rendering;

public sealed class WidgetRendererRegistry
{
    private readonly List<IWidgetRenderer> _renderers = [];

    public WidgetRendererRegistry()
    {
        _renderers.Add(new TextWidgetRenderer());
    }

    public IWidgetRenderer Get(WidgetViewModel widget)
    {
        var renderer = _renderers.FirstOrDefault(x => x.CanRender(widget));
        return renderer ?? throw new InvalidOperationException($"No renderer for {widget.DefinitionId}");
    }
}