using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using OverlayEngine.App.Controls;
using OverlayEngine.Domain.Layouts;
using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.App;

public partial class MainWindow : Window
{
    private readonly Widget _widget;

    public MainWindow()
    {
        InitializeComponent();

        var profile = ProfileFactory.CreateDemo();
        var canvas = this.FindControl<Canvas>("WidgetsCanvas");

        foreach (var widget in profile.Widgets)
        {
            var widgetControl = new WidgetControl(widget);

            Canvas.SetLeft(widgetControl, widget.Position.X);
            Canvas.SetTop(widgetControl, widget.Position.Y);

            canvas.Children.Add(widgetControl);
        }
    }

    private void MainWindow_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
    }

    private void CloseButton_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }

}