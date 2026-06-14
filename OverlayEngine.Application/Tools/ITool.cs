namespace OverlayEngine.Application.Tools;

public interface ITool
{
    void OnPointerDown(PointerContext context);
    void OnPointerMove(PointerContext context);
    void OnPointerUp(PointerContext context);
}