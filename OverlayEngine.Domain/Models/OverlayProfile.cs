using OverlayEngine.Domain.Widgets;

namespace OverlayEngine.Domain.Models;

public sealed class OverlayProfile
{
    public Guid Id { get; }

    public string Name { get; }

    private readonly List<Widget> _widgets;

    public IReadOnlyCollection<Widget> Widgets => _widgets;

    public OverlayProfile(Guid id, string name, IEnumerable<Widget> widgets)
    {
        Id = id;
        Name = name;

        _widgets = new List<Widget>(widgets);
    }
}