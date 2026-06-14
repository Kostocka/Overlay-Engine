using OverlayEngine.Application.Editor;

namespace OverlayEngine.Application.Tools;

public sealed class SelectTool : ITool
{
    private readonly OverlayEditor _editor;

    public SelectTool(OverlayEditor editor)
    {
        _editor = editor;
    }

    public void OnPointerDown(PointerContext context)
    {
        if (context.WidgetId == null)
        {
            _editor.ClearSelection();
            return;
        }

        _editor.Select(context.WidgetId.Value);
    }

    public void OnPointerMove(PointerContext context)
    {
        return;
    }

    public void OnPointerUp(PointerContext context)
    {
        return;
    }
}