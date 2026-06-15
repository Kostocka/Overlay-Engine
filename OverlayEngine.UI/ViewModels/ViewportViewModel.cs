namespace OverlayEngine.UI.ViewModels;

public sealed class ViewportViewModel
{
    public double Zoom { get; set; } = 1.0;

    public double OffsetX { get; set; }

    public double OffsetY { get; set; }

    public double ViewWidth { get; set; }

    public double ViewHeight { get; set; }
}