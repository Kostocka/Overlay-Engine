using Avalonia.Controls;
using OverlayEngine.UI.Controls;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void Init(EditorShellViewModel shell)
    {
        DataContext = shell;

        var canvas = this.FindControl<OverlayCanvas>("Canvas");
        if (canvas == null)
            return;

        canvas.SetController(shell.PointerController);
        canvas.SetPipeline(shell.RenderPipeline);
        canvas.SetCanvas(shell.Canvas);
    }
}