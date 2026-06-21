using OverlayEngine.Application.Editor;
using OverlayEngine.Application.Interaction;
using OverlayEngine.Application.Widgets;
using OverlayEngine.UI.Rendering;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Composition;

public static class ShellModule
{
    public static EditorShellViewModel Build(
        OverlayEditor editor,
        WidgetCatalog catalog,
        CanvasViewModel canvas,
        RenderPipeline pipeline,
        WidgetPointerController pointerController)
    {
        return new EditorShellViewModel(
            editor,
            catalog,
            canvas,
            pipeline,
            pointerController);
    }
}