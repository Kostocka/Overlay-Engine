using System;

namespace OverlayEngine.UI.ViewModels;

public sealed class WidgetViewModel
{
    public Guid Id { get; init; }

    public double X { get; init; }

    public double Y { get; init; }

    public double Width { get; init; }

    public double Height { get; init; }

    public bool IsSelected { get; init; }

    public string Type { get; init; } = "";
}