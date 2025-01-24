namespace dotnet_aspnet_core.Models;

public class Cookbook : ICloneable
{
    public Guid Id { get; } = Guid.NewGuid();
    public List<Category> Categories { get; set; } = [];
    public List<Recipe> Recipes { get; set; } = [];

    public object Clone()
    {
        var clone = (Cookbook)MemberwiseClone();
        clone.Categories = Categories.Select(category => (Category)category.Clone()).ToList();
        clone.Recipes = Recipes.Select(recipe => (Recipe)recipe.Clone()).ToList();
        return clone;
    }
}