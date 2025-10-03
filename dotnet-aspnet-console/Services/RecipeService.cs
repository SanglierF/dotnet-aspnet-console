using dotnet_aspnet_core.IRepositories;
using dotnet_aspnet_core.Models;

namespace dotnet_aspnet_console.Services;

public class RecipeService(IRecipeRepository recipeRepository)
{
    public async Task<IEnumerable<Recipe>> BrowseAsync()
    {
        return await recipeRepository.BrowseAsync();
    }

    public async Task<Recipe?> GetAsync(Guid id)
    {
        return await recipeRepository.GetAsync(id);
    }

    public async Task<Recipe?> FindByName(string name)
    {
        return (await recipeRepository.BrowseAsync()).FirstOrDefault(r => r.Name == name);
    }

    public async Task<Guid> CreateAsync(Recipe recipe)
    {
        return await recipeRepository.Create(recipe);
    }

    public async Task<bool> UpdateAsync(Recipe recipe)
    {
        return await recipeRepository.Update(recipe);
    }

    public async Task<bool> RemoveAsync(Recipe recipe)
    {
        return await recipeRepository.Delete(recipe);
    }
}