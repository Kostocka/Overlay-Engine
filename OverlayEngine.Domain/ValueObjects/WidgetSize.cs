namespace OverlayEngine.Domain.ValueObjects;

public sealed class WidgetSize
{
    public double Width { get; private set; }

    public double Height { get; private set; }

    public WidgetSize(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public void Resize(double width, double height)
    {
        Width = width;
        Height = height;
    }
}