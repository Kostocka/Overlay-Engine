using OverlayEngine.Application.Commands;
using OverlayEngine.Application.Commands.Widgets;
using OverlayEngine.Application.Widgets;
using OverlayEngine.Application.Widgets.Templates;
using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Application.Sessions;

public sealed class SessionWidgetService
{
    private readonly OverlaySessionService _sessionService;
    private readonly IWidgetFactory _widgetFactory;
    private readonly CommandManager _commandManager;

    public SessionWidgetService(OverlaySessionService sessionService, IWidgetFactory widgetFactory, CommandManager commandManager)
    {
        _sessionService = sessionService;
        _widgetFactory = widgetFactory;
        _commandManager = commandManager;
    }

    private OverlaySession Session => _sessionService.GetRequiredSession();

    public Widget Add(WidgetTemplate template)
    {
        var widget = _widgetFactory.Create(template);
        _commandManager.Execute(new AddWidgetCommand(Session, widget));

        return widget;
    }

    public void Remove(Guid widgetId)
    {
        _commandManager.Execute(new RemoveWidgetCommand(Session, widgetId));
    }

    public void Select(Guid widgetId)
    {
        _commandManager.Execute(new SelectWidgetCommand(Session, widgetId));
    }

    public void ClearSelection()
    {
        _commandManager.Execute(new ClearSelectionCommand(Session));
    }

    public Widget? GetSelected()
    {
        return Session.GetSelected();
    }

    public void Move(Guid widgetId, double x, double y)
    {
        _commandManager.Execute(new MoveWidgetCommand(Session, widgetId, new WidgetPosition(x, y)));
    }

    public void Resize(Guid widgetId, double width, double height)
    {
        _commandManager.Execute(new ResizeWidgetCommand(Session, widgetId, new WidgetSize(width, height)));
    }

    public void ChangeStyle(Guid widgetId, WidgetStyle style)
    {
        _commandManager.Execute(new ChangeWidgetStyleCommand(Session, widgetId, style));
    }
}