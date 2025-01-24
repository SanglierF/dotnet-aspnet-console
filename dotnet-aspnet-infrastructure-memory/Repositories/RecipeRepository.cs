using dotnet_aspnet_console.Models;
using dotnet_aspnet_core.IRepositories;
using dotnet_aspnet_infrastructure_memory.Data;

namespace dotnet_aspnet_infrastructure_memory.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly MContext _mContext;

    RecipeRepository(MContext mContext)
    {
        _mContext = mContext;
    }

    public async Task<Recipe?> GetAsync(Guid id)
    {
        await Task.CompletedTask;
        return (Recipe?)_mContext.Recipes.Find(recipe => recipe.Id.Equals(id))?.Clone();
    }

    public async Task<IEnumerable<Recipe>> BrowseAsync()
    {
        await Task.CompletedTask;
        return _mContext.Recipes.Select(cb => (Recipe)cb.Clone()).AsEnumerable();
    }

    public async Task<Guid> Create(Recipe recipe)
    {
        await Task.CompletedTask;
        _mContext.Recipes.Add((Recipe)recipe.Clone());
        return recipe.Id;
    }

    public async Task<bool> Update(Recipe recipe)
    {
        await Task.CompletedTask;
        var updatedRecipe = _mContext.Recipes.Find(cb => cb.Id.Equals(recipe.Id));
        if (updatedRecipe == null) return false;
        updatedRecipe.Name = recipe.Name;
        updatedRecipe.Instructions = recipe.Instructions;
        var updatedCategories =
            _mContext.Categories.FindAll(
                ctxCategory => recipe.Categories.Exists(cbCategory => cbCategory.Id.Equals(ctxCategory.Id)));
        updatedRecipe.Categories = updatedCategories;
        return true;
    }

    public async Task<bool> Delete(Recipe recipe)
    {
        await Task.CompletedTask;
        var recipeIndex = _mContext.Recipes.FindIndex(cb => cb.Id.Equals(recipe.Id));
        if (recipeIndex == -1) return false;
        _mContext.Recipes.RemoveAt(recipeIndex);
        return true;
    }
}