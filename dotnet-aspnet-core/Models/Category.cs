namespace dotnet_aspnet_core.Models;

public class Category : ICloneable
{
    public const string TABLE_NAME = "categories";

    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;

    public override string ToString()
    {
        return Name;
    }

    public object Clone()
    {
        var clone = (Category)MemberwiseClone();
        return clone;
    }
}