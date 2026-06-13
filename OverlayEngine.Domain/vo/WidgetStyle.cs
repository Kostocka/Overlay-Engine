namespace OverlayEngine.Domain.Widgets;

public sealed class WidgetStyle
{
    public string Background { get; private set; }
    public double CornerRadius { get; private set; }
    public double Opacity { get; private set; }

    public WidgetStyle(string background = "#FF2D2D2D", double cornerRadius = 8, double opacity = 1.0)
    {
        Background = background;
        CornerRadius = cornerRadius;
        Opacity = opacity;
    }
}