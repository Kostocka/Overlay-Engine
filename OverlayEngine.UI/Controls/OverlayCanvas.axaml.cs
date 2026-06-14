using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using OverlayEngine.Application.Common;
using OverlayEngine.Application.Interaction;
using OverlayEngine.UI.Rendering;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Controls;

public partial class OverlayCanvas : UserControl
{
    private WidgetPointerController? _controller;
    private CanvasViewModel? _canvas;
    private WidgetRendererRegistry? _renderers;

    public OverlayCanvas()
    {
        InitializeComponent();
    }

    public void SetController(WidgetPointerController controller)
    {
        _controller = controller;
    }

    public void SetCanvas(CanvasViewModel canvas)
    {
        Console.WriteLine("SetCanvas called");

        _canvas = canvas;
    }

    public void SetRenderers(WidgetRendererRegistry renderers)
    {
        _renderers = renderers;
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var p = e.GetPosition(this);

        _controller?.PointerDown(new PointerContext
        {
            Position = new Vector2D(p.X, p.Y),
            Button = PointerButton.Left
        });
    }

    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        var p = e.GetPosition(this);

        _controller?.PointerMove(new PointerContext
        {
            Position = new Vector2D(p.X, p.Y),
            Button = PointerButton.Left
        });
    }

    private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        var p = e.GetPosition(this);

        _controller?.PointerUp(new PointerContext
        {
            Position = new Vector2D(p.X, p.Y),
            Button = PointerButton.Left
        });
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        Console.WriteLine("Render");

        if (_canvas == null)
        {
            Console.WriteLine("_canvas == null");
            return;
        }

        Console.WriteLine($"Widgets: {_canvas.Widgets.Count}");

        foreach (var widget in _canvas.Widgets)
        {
            var renderer = _renderers!.Get(widget);

            renderer.Render(context, widget);
        }
    }
}