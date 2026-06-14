using OverlayEngine.Application.Commands;
using OverlayEngine.Application.Commands.Widgets;
using OverlayEngine.Application.Sessions;
using OverlayEngine.Application.Widgets.Templates;
using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Editor;

public sealed class OverlayEditor
{
    private readonly OverlaySessionService _sessions;
    private readonly SessionWidgetService _widgets;
    private readonly CommandManager _commands;

    public OverlayEditor(OverlaySessionService sessions, SessionWidgetService widgets, CommandManager commands)
    {
        _sessions = sessions;
        _widgets = widgets;
        _commands = commands;
    }

    public OverlaySession Session => _sessions.GetRequiredSession();

    public Widget Create(WidgetTemplate template) => _widgets.Add(template);

    public void Remove(Guid id) => _commands.Execute(new RemoveWidgetCommand(Session, id));

    public void Move(Guid id, double x, double y) => _commands.Execute(new MoveWidgetCommand(Session, id, new WidgetPosition(x, y)));

    public void Resize(Guid id, double w, double h) => _commands.Execute(new ResizeWidgetCommand(Session, id, new WidgetSize(w,h)));

    public void ChangeStyle(Guid id, WidgetStyle style) => _commands.Execute(new ChangeWidgetStyleCommand(Session, id, style));

    public void Select(Guid id) => _commands.Execute(new SelectWidgetCommand(Session, id));

    public void ClearSelection() => _commands.Execute(new ClearSelectionCommand(Session));

    public void EnterEdit() => Session.EnterEditMode();

    public void EnterView() => Session.EnterViewMode();

    public void Undo() => _commands.Undo();

    public void Redo() => _commands.Redo();
}