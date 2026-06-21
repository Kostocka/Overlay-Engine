using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Widgets;

public interface IWidgetFactory
{
    Widget Create(WidgetDefinitionId definitionId);
}