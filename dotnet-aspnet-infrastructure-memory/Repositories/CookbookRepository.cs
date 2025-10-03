using dotnet_aspnet_core.IRepositories;
using dotnet_aspnet_core.Models;
using dotnet_aspnet_infrastructure_memory.Data;

namespace dotnet_aspnet_infrastructure_memory.Repositories;

public class CookbookRepository : ICookbookRepository
{
    private readonly MContext _mContext;

    public CookbookRepository(MContext mContext)
    {
        _mContext = mContext;
    }

    public async Task<Cookbook?> GetAsync(Guid id)
    {
        await Task.CompletedTask;
        return (Cookbook?)_mContext.Cookbooks.Find(cb => cb.Id.Equals(id))?.Clone();
    }

    public async Task<IEnumerable<Cookbook>> BrowseAsync()
    {
        await Task.CompletedTask;
        return _mContext.Cookbooks.Select(cb => (Cookbook)cb.Clone()).AsEnumerable();
    }

    public async Task<Guid> Create(Cookbook cookbook)
    {
        await Task.CompletedTask;
        _mContext.Cookbooks.Add((Cookbook)cookbook.Clone());
        return cookbook.Id;
    }

    public async Task<bool> Update(Cookbook cookbook)
    {
        await Task.CompletedTask;
        var updatedCookbook = _mContext.Cookbooks.Find(cb => cb.Id.Equals(cookbook.Id));
        if (updatedCookbook == null) return false;
        var updatedCategories =
            _mContext.Categories.FindAll(ctxCategory => cookbook.Categories.Exists(cbCategory => cbCategory.Id.Equals(ctxCategory.Id)));
        updatedCookbook.Categories = updatedCategories;
        var updatedRecipes = _mContext.Recipes.FindAll(ctxRecipe => cookbook.Recipes.Exists(cbRecipe => cbRecipe.Id.Equals(ctxRecipe.Id)));
        updatedCookbook.Recipes = updatedRecipes;
        return true;
    }

    public async Task<bool> Delete(Cookbook cookbook)
    {
        await Task.CompletedTask;
        var cbIndex = _mContext.Cookbooks.FindIndex(cb => cb.Id.Equals(cookbook.Id));
        if (cbIndex == -1) return false;
        _mContext.Cookbooks.RemoveAt(cbIndex);
        return true;
    }
}