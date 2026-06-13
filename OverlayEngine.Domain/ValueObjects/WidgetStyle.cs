namespace OverlayEngine.Domain.ValueObjects;

public sealed class WidgetStyle
{
    public string Background { get; private set; }
    public double CornerRadius { get; private set; }
    public double Opacity { get; private set; }

    public static WidgetStyle Default => new("#FF2D2D2D", 8, 1.0);

    public WidgetStyle(string background, double cornerRadius, double opacity)
    {
        Background = background;
        CornerRadius = cornerRadius;
        Opacity = opacity;
    }
}