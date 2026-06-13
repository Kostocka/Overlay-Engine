using Avalonia.Controls;

namespace OverlayEngine.App.Controls.Behaviors;

public interface IWidgetBehavior
{
    void Attach(WidgetChrome chrome);
}