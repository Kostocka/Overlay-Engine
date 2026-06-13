namespace OverlayEngine.Domain.Widgets;

public sealed class Widget
{
    public Guid Id { get; }

    public string Name { get; }

    public WidgetPosition Position { get; }

    public WidgetSize Size { get; }

    public bool IsVisible { get; private set; }

    public Widget(Guid id, string name, WidgetPosition position, WidgetSize size)
    {
        Id = id;
        Name = name;
        Position = position;
        Size = size;

        IsVisible = true;
    }

    public void Show()
    {
        IsVisible = true;
    }

    public void Hide()
    {
        IsVisible = false;
    }
}