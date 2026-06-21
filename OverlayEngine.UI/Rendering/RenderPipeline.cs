using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;
using OverlayEngine.UI.Rendering.Layers;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Rendering;

public sealed class RenderPipeline
{
    private readonly ViewportLayoutService _viewportLayout;
    private readonly CanvasSettings _settings;
    private readonly WidgetRendererRegistry _renderers;
    private readonly IReadOnlyList<ICanvasLayer> _layers;

    public RenderPipeline(IEnumerable<ICanvasLayer> layers ,ViewportLayoutService viewportLayout, CanvasSettings settings, WidgetRendererRegistry renderers)
    {
        _layers = layers.ToList();
        _viewportLayout = viewportLayout;
        _settings = settings;
        _renderers = renderers;
    }

    public void FitViewport(CanvasViewModel canvas, double availableWidth, double availableHeight)
    {
        _viewportLayout.Fit(canvas, availableWidth, availableHeight);
    }

    public void Render(DrawingContext context, CanvasViewModel canvas)
    {
        var renderContext = new CanvasRenderContext(
            canvas,
            new CanvasTransform(canvas),
            _settings,
            _renderers);

        foreach (var layer in _layers)
        {
            layer.Render(context, renderContext);
        }
    }
}