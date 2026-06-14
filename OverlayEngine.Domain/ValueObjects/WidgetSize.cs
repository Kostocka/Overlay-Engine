namespace OverlayEngine.Domain.ValueObjects;

public sealed class WidgetSize
{
    public double Width { get; }
    public double Height { get; }

    public WidgetSize(double width, double height)
    {
        if (width < 50)
            throw new ArgumentOutOfRangeException(nameof(width));

        if (height < 50)
            throw new ArgumentOutOfRangeException(nameof(height));

        Width = width;
        Height = height;
    }
}