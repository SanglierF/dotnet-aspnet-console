using dotnet_aspnet_console.Models;

namespace dotnet_aspnet_console;

public class Cookbook
{
    public List<Category> Categories { get; } = [];
    public List<Recipe> Recipes { get; } = [];

}