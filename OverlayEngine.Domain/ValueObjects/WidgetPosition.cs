namespace OverlayEngine.Domain.ValueObjects;

public sealed class WidgetPosition
{
    public double X { get; }
    public double Y { get; }

    public WidgetPosition(double x, double y)
    {
        if (x < 0)
            throw new ArgumentOutOfRangeException(nameof(x));

        if (y < 0)
            throw new ArgumentOutOfRangeException(nameof(y));

        X = x;
        Y = y;
    }

    public WidgetPosition Translate(double dx, double dy)
    {
        return new WidgetPosition(X + dx, Y + dy);
    }
}