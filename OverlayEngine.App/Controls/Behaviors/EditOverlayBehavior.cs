using Avalonia.Controls;
using OverlayEngine.Domain.Overlay;

namespace OverlayEngine.App.Controls.Behaviors;

public class EditOverlayBehavior : IWidgetBehavior
{
    public void Attach(WidgetChrome chrome)
    {
        var deleteButton = new Button
        {
            Content = "X",
            Width = 20,
            Height = 20
        };

        deleteButton.Click += (_, _) =>
        {
            chrome.RequestRemove();
        };

        chrome.AddOverlay(deleteButton);

        chrome.State.ModeChanged += () =>
        {
            deleteButton.IsVisible = chrome.State.Mode == OverlayMode.Edit;
        };
    }
}