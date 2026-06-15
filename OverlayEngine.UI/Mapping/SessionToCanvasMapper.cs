using System.Linq;
using OverlayEngine.Domain.Models;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Mapping;

public static class SessionToCanvasMapper
{
    public static CanvasViewModel Map(OverlaySession session)
    {
        var vm = new CanvasViewModel
        {
            SceneWidth = session.Width,
            SceneHeight = session.Height
        };

        foreach (var widget in session.Widgets)
        {
            vm.Widgets.Add(
                new WidgetViewModel
                {
                    Id = widget.Id,
                    X = widget.Position.X,
                    Y = widget.Position.Y,
                    Width = widget.Size.Width,
                    Height = widget.Size.Height,
                    IsSelected = session.SelectedWidgetId == widget.Id,
                    Type = widget.Data.GetType().Name
                });
        }

        return vm;
    }

    public static void Update(OverlaySession session, CanvasViewModel canvas)
    {
        canvas.SceneWidth = session.Width;
        canvas.SceneHeight = session.Height;

        canvas.Replace(
            session.Widgets.Select(widget => new WidgetViewModel
            {
                Id = widget.Id,
                X = widget.Position.X,
                Y = widget.Position.Y,
                Width = widget.Size.Width,
                Height = widget.Size.Height,
                IsSelected = session.SelectedWidgetId == widget.Id,
                Type = widget.Data.GetType().Name
            }).ToList());
    }
}