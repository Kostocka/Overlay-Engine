using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace OverlayEngine.App;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        PointerPressed += MainWindow_PointerPressed;
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