using System;
using OverlayEngine.Application.Commands;
using OverlayEngine.Application.Editor;
using OverlayEngine.Application.Sessions;
using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.UI.Composition;
using OverlayEngine.UI.Mapping;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI;

public sealed class Bootstrapper
{
    public OverlaySessionService SessionService { get; }
    public EditorShellViewModel Shell { get; }

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

        var widgetModule = WidgetModule.Build();

        var commandManager = new CommandManager();
        var editor = new OverlayEditor(
            SessionService,
            widgetModule.SessionWidgets,
            commandManager);

        var renderingModule = RenderingModule.Build();
        var interactionModule = InteractionModule.Build(SessionService, editor);

        editor.EnterEdit();

        var created = editor.Create(new WidgetDefinitionId("text"));
        Console.WriteLine($"Created: {created.Id}");

        var canvas = SessionToCanvasMapper.Map(editor.Session);
        var session = SessionService.GetRequiredSession();
        session.SessionChanged += _ => SessionToCanvasMapper.Update(session, canvas);

        Shell = ShellModule.Build(
            editor,
            widgetModule.Catalog,
            canvas,
            renderingModule.RenderPipeline,
            interactionModule.PointerController);
    }
}