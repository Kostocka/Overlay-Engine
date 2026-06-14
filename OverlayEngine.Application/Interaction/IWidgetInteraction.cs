using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;

namespace OverlayEngine.Application.Interaction;

public interface IWidgetInteraction
{
    void Begin(PointerContext context, OverlayEditor editor);

    void Update(PointerContext context, OverlayEditor editor);

    void End(PointerContext context, OverlayEditor editor);
}