using OverlayEngine.Application.Common;
using OverlayEngine.Application.Editor;
using OverlayEngine.Application.Tools;

namespace OverlayEngine.Application.Interaction;

public sealed class WidgetPointerController
{
    private readonly ToolManager _toolManager;
    private readonly OverlayEditor _editor;

    private IWidgetInteraction? _interaction;

    public WidgetPointerController(ToolManager toolManager, OverlayEditor editor)
    {
        _toolManager = toolManager;
        _editor = editor;
    }

    public void PointerDown(PointerContext context)
    {
        if (!_editor.Session.IsEditMode)
            return;
        _interaction = _toolManager.ActiveTool.CreateInteraction(context);

        _interaction?.Begin(context, _editor);
    }

    public void PointerMove(PointerContext context)
    {
        if (!_editor.Session.IsEditMode)
            return;
        _interaction?.Update(context, _editor);
    }

    public void PointerUp(PointerContext context)
    {
        if (!_editor.Session.IsEditMode)
            return;
        _interaction?.End(context, _editor);

        _interaction = null;
    }
}