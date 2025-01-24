namespace dotnet_aspnet_core.Models;

public class Recipe : ICloneable
{
    public const string TABLE_NAME = "recipes";

    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;

    public string Instructions { get; set; } = string.Empty;

    public List<Category> Categories { get; set; } = [];

    public override string ToString()
    {
        var str = $"{Name}: \n {Instructions} \n";
        if (Categories.Count == 0)
        {
            str += "No categories!";
            return str;
        }

        return Categories.Aggregate(str, (current, category) => current + $"{category};");
    }

    public object Clone()
    {
        var clone = (Recipe)MemberwiseClone();
        clone.Categories = Categories.Select(category => (Category)category.Clone()).ToList();
        return clone;
    }
}