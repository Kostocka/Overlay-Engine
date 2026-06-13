namespace OverlayEngine.Domain.Widgets;

public class WidgetPosition
{
    public double X { get; private set; }

    public double Y { get; private set;}

    public WidgetPosition(double x, double y)
    {
        X = x;
        Y = y;
    }

    public void MoveTo(double x, double y)
    {
        X = x;
        Y = y;
    }

    public void Translate(double deltaX, double deltaY)
    {
        X += deltaX;
        Y += deltaY;
    }
}