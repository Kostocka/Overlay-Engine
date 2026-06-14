namespace OverlayEngine.Application.Tools;

public sealed class ToolManager
{
    public ITool ActiveTool { get; private set; }

    public ToolManager(ITool defaultTool)
    {
        ActiveTool = defaultTool;
    }

    public void SetTool(ITool tool)
    {
        ActiveTool = tool;
    }
}