using OverlayEngine.Domain.Widgets;
using Avalonia.Controls;

namespace OverlayEngine.App.Rendering;

public interface IWidgetRenderer
{
    Control Create(Widget widget);
}