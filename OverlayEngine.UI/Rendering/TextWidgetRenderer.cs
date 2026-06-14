using Avalonia;
using Avalonia.Media;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Rendering;

public sealed class TextWidgetRenderer : IWidgetRenderer
{
    public bool CanRender(WidgetViewModel widget)
    {
        return widget.Type == "TextWidgetData";
    }

    public void Render(DrawingContext context, WidgetViewModel widget)
    {
        context.DrawRectangle(
            Brushes.Red,
            null,
            new Rect(
                widget.X,
                widget.Y,
                widget.Width,
                widget.Height));
    }
}