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

    public void Render(DrawingContext context, WidgetViewModel widget, Rect bounds)
    {
        context.DrawRectangle(Brushes.IndianRed, null, bounds);

        var text = widget.Type;
        var typeface = new Typeface("Arial");

        var formatted = new FormattedText(
            text,
            System.Globalization.CultureInfo.InvariantCulture,
            FlowDirection.LeftToRight,
            typeface,
            14,
            Brushes.White);

        context.DrawText(formatted, new Point(bounds.X + 8, bounds.Y + 8));
    }
}