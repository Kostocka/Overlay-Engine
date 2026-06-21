using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Widgets.Definitions;

public interface IWidgetDefinition
{
    WidgetDefinitionId Id { get; }
    string DisplayName { get; }

    Widget CreateDefault();
}