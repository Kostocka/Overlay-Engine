using System;
using OverlayEngine.UI.ViewModels;

namespace OverlayEngine.UI.Rendering;

public sealed class ViewportLayoutService
{
    public void Fit(CanvasViewModel canvas, double availableWidth, double availableHeight)
    {
        if (canvas.SceneWidth <= 0 || canvas.SceneHeight <= 0)
            return;

        if (availableWidth <= 0 || availableHeight <= 0)
            return;

        var zoomX = availableWidth / canvas.SceneWidth;
        var zoomY = availableHeight / canvas.SceneHeight;

        var zoom = Math.Min(zoomX, zoomY);

        canvas.Viewport.Zoom = zoom;
        canvas.Viewport.ViewWidth = availableWidth;
        canvas.Viewport.ViewHeight = availableHeight;
        canvas.Viewport.OffsetX = (availableWidth - canvas.SceneWidth * zoom) / 2;
        canvas.Viewport.OffsetY = (availableHeight - canvas.SceneHeight * zoom) / 2;
    }
}