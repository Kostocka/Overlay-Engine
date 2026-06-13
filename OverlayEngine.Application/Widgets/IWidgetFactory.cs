using OverlayEngine.Application.Widgets.Templates;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Widgets;

public interface IWidgetFactory
{
    Widget Create(WidgetTemplate template);
}