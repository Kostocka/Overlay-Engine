using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Domain.Layouts;

public static class ProfileFactory
{
    public static OverlayProfile CreateDemo()
    {
        var profile = new OverlayProfile("Default");

        profile.AddWidget(
            new Widget(
                Guid.NewGuid(),
                "Telemetry",
                new WidgetPosition(50, 50),
                new WidgetSize(250, 120),
                new WidgetStyle("#FF1E1E1E", 10, 0.95),
                "text"));

        profile.AddWidget(
            new Widget(
                Guid.NewGuid(),
                "Leaderboard",
                new WidgetPosition(350, 50),
                new WidgetSize(250, 120),
                new WidgetStyle("#FF1E1E1E", 10, 0.95),
                "text"));

        profile.AddWidget(
            new Widget(
                Guid.NewGuid(),
                "Weather",
                new WidgetPosition(650, 50),
                new WidgetSize(250, 120),
                new WidgetStyle(),
                "text"));

        return profile;
    }
}