using Avalonia.Controls;
using Avalonia.Interactivity;
using OverlayEngine.Domain.Overlay;

namespace OverlayEngine.App;

public partial class MainWindow : Window
{
    private readonly OverlayEngineApp _app;

    public MainWindow()
    {
        InitializeComponent();

        var canvas = this.FindControl<Canvas>("WidgetsCanvas");

        _app = new OverlayEngineApp();
        _app.Build(canvas);
    }

    private void LockOverlay_Click(object? sender, RoutedEventArgs e)
    {
        if (_app.State.Mode == OverlayMode.Edit)
            _app.State.EnterViewMode();
        else
            _app.State.EnterEditMode();
    }
}