using OverlayEngine.Domain.Models.WidgetsData;
using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Widgets.Definitions;

public sealed class TextWidgetDefinition : IWidgetDefinition
{
    public WidgetDefinitionId Id => new("text");
    public string DisplayName => "Text";

    public Widget CreateDefault()
    {
        return new Widget(
            Guid.NewGuid(),
            "Text",
            Id,
            new WidgetPosition(100, 100),
            new WidgetSize(300, 100),
            WidgetStyle.Default,
            new TextWidgetData("Hello"));
    }
}