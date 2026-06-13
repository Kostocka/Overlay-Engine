namespace OverlayEngine.Domain.Models.WidgetsData;

public sealed class ChartWidgetData : WidgetData
{
    public string Text { get; }

    public ChartWidgetData()
    {
        Text = "test";
    }
}