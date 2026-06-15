using Avalonia;
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
    private RenderPipeline? _pipeline;

    public OverlayCanvas()
    {
        InitializeComponent();
        SizeChanged += (_, __) => UpdateViewport();
    }

    public void SetController(WidgetPointerController controller) => _controller = controller;

    public void SetPipeline(RenderPipeline pipeline) => _pipeline = pipeline;

    public void SetCanvas(CanvasViewModel canvas)
    {
        _canvas = canvas;
        canvas.Changed += InvalidateVisual;
        UpdateViewport();
    }

    private void UpdateViewport()
    {
        if (_canvas == null || _pipeline == null)
            return;

        if (Bounds.Width <= 0 || Bounds.Height <= 0)
            return;

        _pipeline.FitViewport(_canvas, Bounds.Width, Bounds.Height);
        InvalidateVisual();
    }

    private Vector2D ToScene(Vector2D screen)
    {
        if (_canvas == null)
            return screen;

        var transform = new CanvasTransform(_canvas);
        var scene = transform.ScreenToScene(new Point(screen.X, screen.Y));

        return new Vector2D(scene.X, scene.Y);
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var p = e.GetPosition(this);

        _controller?.PointerDown(new PointerContext
        {
            Position = ToScene(new Vector2D(p.X, p.Y)),
            Button = PointerButton.Left
        });
    }

    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        var p = e.GetPosition(this);

        _controller?.PointerMove(new PointerContext
        {
            Position = ToScene(new Vector2D(p.X, p.Y)),
            Button = PointerButton.Left
        });
    }

    private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        var p = e.GetPosition(this);

        _controller?.PointerUp(new PointerContext
        {
            Position = ToScene(new Vector2D(p.X, p.Y)),
            Button = PointerButton.Left
        });
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        if (_canvas == null || _pipeline == null)
            return;

        _pipeline.Render(context, _canvas);
    }
}