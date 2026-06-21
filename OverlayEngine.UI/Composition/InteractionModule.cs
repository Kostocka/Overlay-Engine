using OverlayEngine.Application.Editor;
using OverlayEngine.Application.Interaction;
using OverlayEngine.Application.Sessions;
using OverlayEngine.Application.Tools;

namespace OverlayEngine.UI.Composition;

public sealed record InteractionModuleResult(
    EditorBoundsService BoundsService,
    WidgetPointerController PointerController);

public static class InteractionModule
{
    public static InteractionModuleResult Build(OverlaySessionService sessionService, OverlayEditor editor)
    {
        var boundsService = new EditorBoundsService();
        var hitTest = new WidgetHitTestService(sessionService, boundsService);
        var selectTool = new SelectTool(hitTest);
        var toolManager = new ToolManager(selectTool);

        var pointerController = new WidgetPointerController(toolManager, editor);

        return new InteractionModuleResult(boundsService, pointerController);
    }
}