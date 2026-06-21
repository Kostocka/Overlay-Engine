using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;

namespace OverlayEngine.Application.Interaction.Interactions;

public sealed class EmptyCanvasInteraction : IWidgetInteraction
{
    public void Begin(PointerContext context, OverlayEditor editor)
    {
        editor.ClearSelection();
    }

    public void Update(PointerContext context, OverlayEditor editor) { }

    public void End(PointerContext context, OverlayEditor editor) { }
}