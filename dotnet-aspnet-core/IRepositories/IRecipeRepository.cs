using dotnet_aspnet_core.Models;

namespace dotnet_aspnet_core.IRepositories;

public interface IRecipeRepository
{
    public Task<Recipe?> GetAsync(Guid id);

    public Task<IEnumerable<Recipe>> BrowseAsync();

    public Task<Guid> Create(Recipe recipe);

    public Task<bool> Update(Recipe recipe);

    public Task<bool> Delete(Recipe recipe);
}