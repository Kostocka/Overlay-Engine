using System;
using OverlayEngine.Application.Commands;
using OverlayEngine.Application.Editor;
using OverlayEngine.Application.Interaction;
using OverlayEngine.Application.Sessions;
using OverlayEngine.Application.Tools;
using OverlayEngine.Application.Widgets;
using OverlayEngine.Application.Widgets.Templates;
using OverlayEngine.Domain.Models;
using OverlayEngine.UI.Mapping;
using OverlayEngine.UI.Rendering;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI;

public sealed class Bootstrapper
{
    public OverlayEditor Editor { get; }
    public WidgetPointerController PointerController { get; }
    public OverlaySessionService SessionService { get; }
    public WidgetRendererRegistry Renderers { get; }
    public CanvasViewModel Canvas { get; private set; }

    public Bootstrapper()
    {
        SessionService = new OverlaySessionService();
        var profile = new OverlayProfile(Guid.NewGuid(), "Default", 1920,1080, []);
        var editorBounds = new EditorBounds(1920, 1080);
        var boundsConstraint = new WidgetBoundsConstraint(editorBounds);

        SessionService.OpenProfile(profile);

        var widgetFactory = new WidgetFactory();
        var sessionWidgets = new SessionWidgetService(widgetFactory);
        var commandManager = new CommandManager();

        Editor = new OverlayEditor(SessionService, sessionWidgets, commandManager);
        Editor.EnterEdit();

        // test
        var created = Editor.Create(new TextWidgetTemplate());

        Console.WriteLine($"Created: {created.Id}");

        Console.WriteLine(
            $"Session widgets: {Editor.Session.Widgets.Count}");

        Canvas = SessionToCanvasMapper.Map(Editor.Session);

        Console.WriteLine(
            $"Canvas widgets: {Canvas.Widgets.Count}");

        var session = SessionService.GetRequiredSession();
        session.SessionChanged += _ => { SessionToCanvasMapper.Update(session, Canvas); };

        var hitTest = new WidgetHitTestService(SessionService);
        var selectTool = new SelectTool(hitTest);
        var toolManager = new ToolManager(selectTool);

        PointerController = new WidgetPointerController(toolManager, Editor);
        Renderers = new WidgetRendererRegistry();
    }
}