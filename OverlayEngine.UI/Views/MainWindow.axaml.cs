using System;
using Avalonia.Controls;
using OverlayEngine.UI.Controls;

namespace OverlayEngine.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void Init(Bootstrapper bootstrapper)
    {
        var canvas = this.FindControl<OverlayCanvas>("Canvas");

        canvas?.SetController(bootstrapper.PointerController);
        canvas?.SetCanvas(bootstrapper.Canvas);
        canvas?.SetPipeline(bootstrapper.RenderPipeline);
    }
}