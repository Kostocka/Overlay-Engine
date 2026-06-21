using Avalonia;
using Avalonia.Media;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Rendering;

public sealed class TextWidgetRenderer : IWidgetRenderer
{
    public bool CanRender(WidgetViewModel widget) => widget.DefinitionId.Value == "text";

    public void Render(DrawingContext context, WidgetViewModel widget, WidgetRenderContext renderContext)
    {
        var rect = renderContext.DrawArea.ToRect();

        context.DrawRectangle(
            Brushes.IndianRed,
            null,
            rect);

        var formatted = new FormattedText(
            "Text",
            System.Globalization.CultureInfo.InvariantCulture,
            FlowDirection.LeftToRight,
            new Typeface("Arial"),
            14,
            Brushes.White);

        context.DrawText(formatted, new Point(rect.X + 8, rect.Y + 8));
    }
}