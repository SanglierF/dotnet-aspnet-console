using dotnet_aspnet_core.Models;

namespace dotnet_aspnet_infrastructure_memory.Data;

/// <summary>
/// In memory context.
/// </summary>
public class MContext
{
    public List<Cookbook> Cookbooks { get; } = new();
    public List<Category> Categories { get; } = new();
    public List<Recipe> Recipes { get; } = new();
}