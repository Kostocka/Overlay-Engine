using OverlayEngine.Application.Common;
using OverlayEngine.Application.Interaction;

public interface ITool
{
    IWidgetInteraction? CreateInteraction(PointerContext context);
}