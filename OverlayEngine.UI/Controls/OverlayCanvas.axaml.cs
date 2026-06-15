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
    private WidgetRendererRegistry? _renderers;
    private CanvasSettings? _settings;
    private ViewportLayoutService? _viewport;

    public OverlayCanvas()
    {
        InitializeComponent();
        SizeChanged += (_, __) => UpdateViewport();
    }

    public void SetController(WidgetPointerController controller) => _controller = controller;

    public void SetRenderers(WidgetRendererRegistry renderers) => _renderers = renderers;

    public void SetSettings(CanvasSettings settings) => _settings = settings;

    public void SetViewport(ViewportLayoutService viewport) => _viewport = viewport;

    public void SetCanvas(CanvasViewModel canvas)
    {
        _canvas = canvas;
        canvas.Changed += () => InvalidateVisual();
        UpdateViewport();
    }

    private void UpdateViewport()
    {
        if (_canvas == null || _viewport == null)
            return;

        if (Bounds.Width <= 0 || Bounds.Height <= 0)
            return;

        _viewport.Fit(_canvas, Bounds.Width, Bounds.Height);
        InvalidateVisual();
    }

    private Vector2D ToScene(Vector2D screen)
    {
        if (_canvas == null)
            return screen;

        var transform = new CanvasTransform(_canvas);
        var p = transform.ScreenToScene(screen.X, screen.Y);

        return new Vector2D(p.X, p.Y);
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

        if (_canvas == null || _renderers == null)
            return;

        var transform = new CanvasTransform(_canvas);

        if (_settings?.ShowBounds == true)
            DrawBounds(context, transform);

        foreach (var widget in _canvas.Widgets)
        {
            var renderer = _renderers.Get(widget);

            var screenBounds = transform.SceneToScreen(new Rect(
                widget.X,
                widget.Y,
                widget.Width,
                widget.Height));

            if (widget.IsSelected && _settings?.ShowSelection == true)
            {
                context.DrawRectangle(
                    null,
                    new Pen(Brushes.DeepSkyBlue, 2),
                    screenBounds);
            }

            renderer.Render(context, widget, screenBounds);
        }
    }

    private void DrawBounds(DrawingContext context, CanvasTransform transform)
    {
        var sceneRect = new Rect(0, 0, _canvas!.SceneWidth, _canvas.SceneHeight);

        var screenRect = transform.SceneToScreen(sceneRect);

        var pen = new Pen(Brushes.DimGray, _settings?.BoundsThickness ?? 1);

        context.DrawRectangle(null, pen, screenRect);
    }
}