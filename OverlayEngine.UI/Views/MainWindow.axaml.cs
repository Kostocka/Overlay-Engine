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
        Console.WriteLine("Init");

        var canvas = this.FindControl<OverlayCanvas>("Canvas");

        Console.WriteLine(canvas == null
            ? "Canvas NOT FOUND"
            : "Canvas FOUND");

        canvas?.SetController(bootstrapper.PointerController);
        canvas?.SetCanvas(bootstrapper.Canvas);
        canvas?.SetRenderers(bootstrapper.Renderers);
    }
}