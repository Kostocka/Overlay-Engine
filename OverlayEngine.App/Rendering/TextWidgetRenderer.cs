using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.App.Rendering;

public sealed class TextWidgetRenderer : IWidgetRenderer
{
    public Control Create(Widget widget)
    {
        return new Border
        {
            Width = widget.Size.Width,
            Height = widget.Size.Height,
            Background = new SolidColorBrush(Color.Parse(widget.Style.Background)),
            CornerRadius = new CornerRadius(widget.Style.CornerRadius),
            Opacity = widget.Style.Opacity,

            Child = new TextBlock
            {
                Text = widget.Name,
                Margin = new Thickness(10),
                FontSize = 18
            }
        };
    }
}