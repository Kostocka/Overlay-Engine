using Avalonia;
using Avalonia.Input;
using Avalonia.Controls;
using Avalonia.Media;

using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.App.Controls;

public sealed class WidgetControl : Border
{
    private readonly Widget _widget;
    private bool _isDragging;
    private Point _lastPosition;

    public WidgetControl(Widget widget)
    {
        _widget = widget;

        Width = _widget.Size.Width;
        Height = _widget.Size.Height;

        Background = Brushes.DarkSlateGray;

        CornerRadius = new CornerRadius(8);

        Child = new TextBlock
        {
            Text = _widget.Name,
            FontSize = 20,
            Margin = new Thickness(10)
        };

        PointerPressed += OnPointerPressed;
        PointerMoved += OnPointerMoved;
        PointerReleased += OnPointerReleased;
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        _isDragging = true;
        _lastPosition = e.GetPosition(Parent as Control);

        e.Pointer.Capture(this);
    }

    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (!_isDragging)
            return;

        var currentPosition =
            e.GetPosition(Parent as Control);

        var deltaX =
            currentPosition.X - _lastPosition.X;

        var deltaY =
            currentPosition.Y - _lastPosition.Y;

        _widget.Position.Translate(deltaX, deltaY);

        Canvas.SetLeft(this, _widget.Position.X);
        Canvas.SetTop(this, _widget.Position.Y);

        _lastPosition = currentPosition;
    }

    private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        _isDragging = false;

        e.Pointer.Capture(null);
    }
}