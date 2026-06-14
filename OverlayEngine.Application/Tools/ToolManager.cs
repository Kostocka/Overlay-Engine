namespace OverlayEngine.Application.Tools;

public sealed class ToolManager
{
    private ITool? _activeTool;

    public void SetTool(ITool tool)
    {
        _activeTool = tool;
    }

    public void PointerDown(PointerContext ctx) => _activeTool?.OnPointerDown(ctx);

    public void PointerMove(PointerContext ctx) => _activeTool?.OnPointerMove(ctx);

    public void PointerUp(PointerContext ctx) => _activeTool?.OnPointerUp(ctx);
}