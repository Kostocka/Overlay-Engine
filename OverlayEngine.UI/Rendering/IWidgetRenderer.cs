using Avalonia.Media;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Rendering;

public interface IWidgetRenderer
{
    bool CanRender(WidgetViewModel widget);

    void Render(DrawingContext context, WidgetViewModel widget);
}