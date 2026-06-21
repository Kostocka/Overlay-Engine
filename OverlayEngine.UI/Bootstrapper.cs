using System;
using OverlayEngine.Application.Commands;
using OverlayEngine.Application.Editor;
using OverlayEngine.Application.Interaction;
using OverlayEngine.Application.Sessions;
using OverlayEngine.Application.Tools;
using OverlayEngine.Application.Widgets;
using OverlayEngine.Application.Widgets.Definitions;
using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.UI.Mapping;
using OverlayEngine.UI.Rendering;
using OverlayEngine.UI.Rendering.Layers;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI;

public sealed class Bootstrapper
{
    public OverlayEditor Editor { get; }
    public WidgetPointerController PointerController { get; }
    public OverlaySessionService SessionService { get; }
    public WidgetRendererRegistry Renderers { get; }
    public CanvasViewModel Canvas { get; private set; }
    public CanvasSettings CanvasSettings { get; }
    public ViewportLayoutService Viewport { get; }
    public RenderPipeline RenderPipeline { get; }
    public WidgetCatalog WidgetCatalog { get; }

    public Bootstrapper()
    {
        SessionService = new OverlaySessionService();

        var profile = new OverlayProfile(
            Guid.NewGuid(),
            "Default",
            1920,
            1080,
            []);

        SessionService.OpenProfile(profile);

        var boundsService = new EditorBoundsService();

        WidgetCatalog = new WidgetCatalog(new IWidgetDefinition[]
        {
            new TextWidgetDefinition(),
        });

        var widgetFactory = new WidgetFactory(WidgetCatalog);
        var sessionWidgets = new SessionWidgetService(widgetFactory);
        var commandManager = new CommandManager();

        Editor = new OverlayEditor(SessionService, sessionWidgets, commandManager);
        Editor.EnterEdit();

        var created = Editor.Create(new WidgetDefinitionId("text"));

        Canvas = SessionToCanvasMapper.Map(Editor.Session);

        var session = SessionService.GetRequiredSession();
        session.SessionChanged += _ => SessionToCanvasMapper.Update(session, Canvas);

        var hitTest = new WidgetHitTestService(SessionService, boundsService);
        var selectTool = new SelectTool(hitTest);
        var toolManager = new ToolManager(selectTool);

        PointerController = new WidgetPointerController(toolManager, Editor);

        Renderers = new WidgetRendererRegistry();
        Viewport = new ViewportLayoutService();

        CanvasSettings = new CanvasSettings
        {
            ShowBounds = true,
            ShowSelection = true,
            ShowGrid = false
        };

        RenderPipeline = new RenderPipeline(
            new ICanvasLayer[]
            {
                new GridLayer(),
                new SceneBoundsLayer(),
                new WidgetLayer(),
                new SelectionLayer()
            },
            Viewport,
            CanvasSettings,
            Renderers);
    }
}