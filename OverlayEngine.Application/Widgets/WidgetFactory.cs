using OverlayEngine.Application.Widgets.Templates;
using OverlayEngine.Domain.Models.WidgetsData;
using OverlayEngine.Domain.Widgets;
using OverlayEngine.Domain.ValueObjects;

namespace OverlayEngine.Application.Widgets;

public sealed class WidgetFactory : IWidgetFactory
{
    public Widget Create(WidgetTemplate template)
    {
        return template switch
        {
            TextWidgetTemplate => CreateText(),

            ChartWidgetTemplate => CreateChart(),

            _ => throw new NotSupportedException($"Unknown template: {template.GetType().Name}")
        };
    }

    private Widget CreateText()
    {
        return new Widget(
            Guid.NewGuid(),
            "Text",
            new WidgetPosition(100, 100),
            new WidgetSize(300, 100),
            WidgetStyle.Default,
            new TextWidgetData("Hello"));
    }

    private Widget CreateChart()
    {
        return new Widget(
            Guid.NewGuid(),
            "Chart",
            new WidgetPosition(100, 100),
            new WidgetSize(400, 200),
            WidgetStyle.Default,
            new ChartWidgetData());
    }
}