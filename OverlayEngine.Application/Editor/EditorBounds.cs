namespace OverlayEngine.Application.Editor;

public sealed class EditorBounds
{
    public double Width { get; }
    public double Height { get; }

    public EditorBounds(double width, double height)
    {
        Width = width;
        Height = height;
    }
}