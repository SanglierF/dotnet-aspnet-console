namespace dotnet_aspnet_console.Models;

public class Recipe
{
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
}