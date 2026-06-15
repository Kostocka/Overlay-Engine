using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Rendering;

public sealed record CanvasRenderContext(CanvasViewModel Canvas, CanvasTransform Transform, CanvasSettings Settings, WidgetRendererRegistry Renderers);