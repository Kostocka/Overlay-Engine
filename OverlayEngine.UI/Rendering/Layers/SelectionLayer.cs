using Avalonia;
using Avalonia.Media;

namespace OverlayEngine.UI.Rendering.Layers;

public sealed class SelectionLayer : ICanvasLayer
{
    public void Render(DrawingContext context, CanvasRenderContext renderContext)
    {
        if (!renderContext.Settings.ShowSelection)
            return;

        foreach (var widget in renderContext.Canvas.Widgets)
        {
            if (!widget.IsSelected)
                continue;

            var screenRect = renderContext.Transform.SceneToScreen(
                new Rect(widget.X, widget.Y, widget.Width, widget.Height));

            context.DrawRectangle(
                null,
                new Pen(Brushes.DeepSkyBlue, 2),
                screenRect);
        }
    }
}