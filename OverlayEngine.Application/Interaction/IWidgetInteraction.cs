using OverlayEngine.Application.Common;

namespace OverlayEngine.Application.Interaction;

public interface IWidgetInteraction
{
    void Begin(PointerContext context);

    void Update(PointerContext context);

    void End(PointerContext context);
}