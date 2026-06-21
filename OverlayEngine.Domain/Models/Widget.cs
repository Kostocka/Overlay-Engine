using OverlayEngine.Domain.Models.WidgetsData;
using OverlayEngine.Domain.ValueObjects;

namespace OverlayEngine.Domain.Widgets;

public sealed class Widget
{
    public Guid Id { get; }

    public string Name { get; }

    public WidgetDefinitionId DefinitionId { get; }

    public WidgetData Data { get; }

    public WidgetPosition Position { get; private set; }

    public WidgetSize Size { get; private set; }

    public WidgetStyle Style { get; private set; }

    public Widget(Guid id, string name, WidgetDefinitionId definitionId,  WidgetPosition position, WidgetSize size, WidgetStyle style, WidgetData widgetData)
    {
        Id = id;
        Name = name;
        DefinitionId = definitionId;
        Position = position;
        Size = size;
        Style = style;
        Data = widgetData;
    }

    public void MoveTo(WidgetPosition position)
    {
        Position = position;
    }

    public void Resize(WidgetSize size)
    {
        Size = size;
    }

    public void ChangeStyle(WidgetStyle style)
    {
        Style = style;
    }
}