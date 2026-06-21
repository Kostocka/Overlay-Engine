namespace OverlayEngine.Domain.ValueObjects;

public sealed record WidgetDefinitionId(string Value)
{
    public override string ToString() => Value;
}