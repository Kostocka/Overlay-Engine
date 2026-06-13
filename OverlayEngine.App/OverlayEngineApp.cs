using Avalonia.Controls;
using OverlayEngine.App.Controls;
using OverlayEngine.App.Controls.Behaviors;
using OverlayEngine.App.Rendering;
using OverlayEngine.Domain.Overlay;
using OverlayEngine.Domain.Layouts;

namespace OverlayEngine.App;

public sealed class OverlayEngineApp
{
    private readonly WidgetRendererRegistry _registry;
    private readonly OverlayState _state;
    private readonly OverlayContext _context;

    private Canvas? _canvas;

    public OverlayEngineApp()
    {
        _state = new OverlayState();
        _context = new OverlayContext();

        _registry = new WidgetRendererRegistry();
        _registry.Register("text", new TextWidgetRenderer());
    }

    public void Build(Canvas canvas)
    {
        _canvas = canvas;

        var profile = ProfileFactory.CreateDemo();
        _context.SetWidgets(profile.Widgets);

        Render();
    }

    public void Render()
    {
        if (_canvas == null) return;

        _canvas.Children.Clear();

        foreach (var widget in _context.Widgets)
        {
            var renderer = _registry.Resolve(widget.RendererKey);
            var ui = renderer.Create(widget);

            var chrome = new WidgetChrome(widget, _state, ui);

            chrome.RemoveRequested += id =>
            {
                _context.RemoveWidget(id);
                Render();
            };

            new DragBehavior().Attach(chrome);
            new EditOverlayBehavior().Attach(chrome);
            new ResizeBehavior().Attach(chrome);

            Canvas.SetLeft(chrome, widget.Position.X);
            Canvas.SetTop(chrome, widget.Position.Y);

            _canvas.Children.Add(chrome);
        }
    }

    public OverlayState State => _state;
}