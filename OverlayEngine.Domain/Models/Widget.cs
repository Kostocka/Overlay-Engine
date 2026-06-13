using OverlayEngine.Domain.Models.WidgetsData;
using OverlayEngine.Domain.ValueObjects;

namespace OverlayEngine.Domain.Widgets;

public sealed class Widget
{
    public Guid Id { get; }

    public string Name { get; }

    public WidgetData Data { get; }

    public WidgetPosition Position { get; private set; }

    public WidgetSize Size { get; private set; }

    public WidgetStyle Style { get; private set; }

    public Widget(Guid id, string name, WidgetPosition position, WidgetSize size, WidgetStyle style, WidgetData widgetData)
    {
        Id = id;
        Name = name;
        Position = position;
        Size = size;
        Style = style;
        Data = widgetData;
    }

    public void MoveTo(double x, double y)
    {
        Position = new WidgetPosition(x, y);
    }

    public void Resize(double width, double height)
    {
        Size = new WidgetSize(width, height);
    }

    public void ChangeStyle(WidgetStyle style)
    {
        Style = style;
    }
}