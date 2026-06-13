namespace OverlayEngine.Domain.Models;

public sealed class TextWidgetData : WidgetData
{
    public string Text { get; }

    public TextWidgetData(string text)
    {
        Text = text;
    }
}