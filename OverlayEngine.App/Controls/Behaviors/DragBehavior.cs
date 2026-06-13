using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using OverlayEngine.Domain.Widgets;
using OverlayEngine.Domain.Overlay;

namespace OverlayEngine.App.Controls.Behaviors;

public class DragBehavior : IWidgetBehavior
{
    private WidgetChrome? _chrome;
    private Widget? _widget;
    private OverlayState? _state;

    private bool _dragging;
    private Point _startMouse;
    private Point _startPos;

    public void Attach(WidgetChrome chrome)
    {
        _chrome = chrome;
        _widget = chrome.Widget;
        _state = chrome.State;

        chrome.PointerPressed += OnPressed;
        chrome.PointerMoved += OnMoved;
        chrome.PointerReleased += OnReleased;
    }

    private void OnPressed(object? sender, PointerPressedEventArgs e)
    {
        if (_state!.Mode == OverlayMode.View)
            return;

        _dragging = true;
        _startMouse = e.GetPosition(_chrome!.Parent as Control);
        _startPos = new Point(_widget!.Position.X, _widget.Position.Y);

        e.Pointer.Capture(_chrome);
    }

    private void OnMoved(object? sender, PointerEventArgs e)
    {
        if (!_dragging) return;

        var p = e.GetPosition(_chrome!.Parent as Control);

        var dx = p.X - _startMouse.X;
        var dy = p.Y - _startMouse.Y;

        var x = _startPos.X + dx;
        var y = _startPos.Y + dy;

        _widget!.Position.MoveTo(x, y);

        Canvas.SetLeft(_chrome!, x);
        Canvas.SetTop(_chrome!, y);
    }

    private void OnReleased(object? sender, PointerReleasedEventArgs e)
    {
        _dragging = false;
        e.Pointer.Capture(null);
    }
}