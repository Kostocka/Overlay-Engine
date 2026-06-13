using System;
using System.Collections.Generic;

namespace OverlayEngine.App.Rendering;

public sealed class WidgetRendererRegistry
{
    private readonly Dictionary<string, IWidgetRenderer> _map = new();

    public void Register(string key, IWidgetRenderer renderer)
    {
        _map[key] = renderer;
    }

    public IWidgetRenderer Resolve(string key)
    {
        if (_map.TryGetValue(key, out var renderer))
            return renderer;

        throw new Exception($"Renderer not found: {key}");
    }
}