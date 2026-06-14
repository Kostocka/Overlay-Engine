using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using OverlayEngine.UI.ViewModels;
using OverlayEngine.UI.Views;

namespace OverlayEngine.UI;

public partial class App : Avalonia.Application
{
    public Bootstrapper Bootstrapper { get; private set; } = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var bootstrapper = new Bootstrapper();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var window = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };

            window.Init(bootstrapper);

            desktop.MainWindow = window;
        }

        base.OnFrameworkInitializationCompleted();
    }
}