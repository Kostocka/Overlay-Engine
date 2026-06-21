using OverlayEngine.UI.Rendering;
using OverlayEngine.UI.Rendering.Layers;

namespace OverlayEngine.UI.Composition;

public sealed record RenderingModuleResult(
    WidgetRendererRegistry Renderers,
    ViewportLayoutService Viewport,
    CanvasSettings CanvasSettings,
    RenderPipeline RenderPipeline);

public static class RenderingModule
{
    public static RenderingModuleResult Build()
    {
        var renderers = new WidgetRendererRegistry();
        var viewport = new ViewportLayoutService();

        var canvasSettings = new CanvasSettings
        {
            ShowBounds = true,
            ShowSelection = true,
            ShowGrid = false
        };

        var layers = new ICanvasLayer[]
        {
            new GridLayer(),
            new SceneBoundsLayer(),
            new WidgetLayer(),
            new SelectionLayer()
        };

        var pipeline = new RenderPipeline(
            layers,
            viewport,
            canvasSettings,
            renderers);

        return new RenderingModuleResult(
            renderers,
            viewport,
            canvasSettings,
            pipeline);
    }
}