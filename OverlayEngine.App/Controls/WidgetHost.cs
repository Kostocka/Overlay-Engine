using Avalonia.Controls;
using Avalonia.Input;
using OverlayEngine.Domain.Overlay;
using OverlayEngine.Domain.Widgets;
using Avalonia;

namespace OverlayEngine.App.Controls;

public class WidgetHost : ContentControl
{
    private readonly Widget _widget;
    private readonly OverlayState _state;

    private bool _dragging;
    private Point _startMouse;
    private Point _startWidget;

    public WidgetHost(Widget widget, OverlayState state, Control content)
    {
        _widget = widget;
        _state = state;

        Content = content;

        PointerPressed += OnPressed;
        PointerMoved += OnMoved;
        PointerReleased += OnReleased;
    }

    private void OnPressed(object? sender, PointerPressedEventArgs e)
    {
        if (_state.Mode == OverlayMode.View)
            return;

        _dragging = true;
        _startMouse = e.GetPosition(this.Parent as Control);
        _startWidget = new Point(_widget.Position.X, _widget.Position.Y);

        e.Pointer.Capture(this);
    }

    private void OnMoved(object? sender, PointerEventArgs e)
    {
        if (!_dragging)
            return;

        var pos = e.GetPosition(this.Parent as Control);

        var dx = pos.X - _startMouse.X;
        var dy = pos.Y - _startMouse.Y;

        var newX = _startWidget.X + dx;
        var newY = _startWidget.Y + dy;

        _widget.Position.MoveTo(newX, newY);

        Canvas.SetLeft(this, newX);
        Canvas.SetTop(this, newY);
    }

    private void OnReleased(object? sender, PointerReleasedEventArgs e)
    {
        _dragging = false;
        e.Pointer.Capture(null);
    }
}