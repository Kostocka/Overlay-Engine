using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using OverlayEngine.UI.Views;

namespace OverlayEngine.UI;

public partial class App : Avalonia.Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var bootstrapper = new Bootstrapper();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var window = new MainWindow();
            window.Init(bootstrapper.Shell);
            desktop.MainWindow = window;
        }

        base.OnFrameworkInitializationCompleted();
    }
}