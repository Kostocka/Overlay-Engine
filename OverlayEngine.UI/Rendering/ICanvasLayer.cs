using Avalonia.Media;

namespace OverlayEngine.UI.Rendering;

public interface ICanvasLayer
{
    void Render(DrawingContext context, CanvasRenderContext renderContext);
}