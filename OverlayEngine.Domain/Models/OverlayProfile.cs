using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Domain.Models;

public sealed class OverlayProfile
{
    public Guid Id { get; }

    public string Name { get; }
    
    public double Width { get; }

    public double Height { get; }

    private readonly List<Widget> _widgets;

    public IReadOnlyCollection<Widget> Widgets => _widgets;

    public OverlayProfile(Guid id, string name, double width, double height, IEnumerable<Widget> widgets)
    {
        Id = id;
        Name = name;
        Width = width;
        Height = height;

        _widgets = new List<Widget>(widgets);
    }
}