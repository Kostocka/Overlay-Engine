namespace OverlayEngine.Domain.Widgets;

public sealed class Widget
{
    public Guid Id { get; }

    public string RendererKey { get; }

    public string Name { get; }

    public WidgetPosition Position { get; }

    public WidgetSize Size { get; }

    public WidgetStyle Style { get; }

    public Widget(Guid id, string name, WidgetPosition position, WidgetSize size, WidgetStyle style, string rendererKey)
    {
        Id = id;
        Name = name;
        Position = position;
        Size = size;
        Style = style;
        RendererKey = rendererKey;
    }
}