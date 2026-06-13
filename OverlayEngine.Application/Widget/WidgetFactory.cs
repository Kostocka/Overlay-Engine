using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.Widgets;
using OverlayEngine.Domain.ValueObjects;

namespace OverlayEngine.Application.Widgets;

public sealed class WidgetFactory : IWidgetFactory
{
    public Widget CreateTextWidget()
    {
        return new Widget(
            Guid.NewGuid(),
            "Telemetry",
            new WidgetPosition(100, 100),
            new WidgetSize(300, 100),
            new WidgetStyle("#202020", 1.0, 8),
            new TextWidgetData("New Widget"));
    }
}