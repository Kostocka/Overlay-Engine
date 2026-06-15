using OverlayEngine.Application.Common;
using OverlayEngine.Domain.Models;
using OverlayEngine.Domain.ValueObjects;

namespace OverlayEngine.Application.Editor;

public sealed class EditorBoundsService
{
    public WidgetPosition ClampPosition(OverlaySession session, double x, double y, double width, double height)
    {
        x = Math.Clamp(x, 0, session.Width - width);
        y = Math.Clamp(y, 0, session.Height - height);

        return new WidgetPosition(x, y);
    }

    public ResizeResult ClampResize(OverlaySession session, double startX, double startY, double startWidth, double startHeight, double dx, double dy, int horizontal, int vertical)
    {
        var min = EditorInteractionSettings.MinWidgetSize;

        var x = startX;
        var y = startY;
        var width = startWidth;
        var height = startHeight;

        if (horizontal > 0)
        {
            var right = Math.Clamp(startX + startWidth + dx, startX + min, session.Width);
            width = right - startX;
        }
        else if (horizontal < 0)
        {
            var left = Math.Clamp(startX + dx, 0, startX + startWidth - min);
            x = left;
            width = (startX + startWidth) - left;
        }

        if (vertical > 0)
        {
            var bottom = Math.Clamp(startY + startHeight + dy, startY + min, session.Height);
            height = bottom - startY;
        }
        else if (vertical < 0)
        {
            var top = Math.Clamp(startY + dy, 0, startY + startHeight - min);
            y = top;
            height = (startY + startHeight) - top;
        }

        x = Math.Clamp(x, 0, session.Width - min);
        y = Math.Clamp(y, 0, session.Height - min);
        width = Math.Clamp(width, min, session.Width - x);
        height = Math.Clamp(height, min, session.Height - y);

        return new ResizeResult(x, y, width, height);
    }
}