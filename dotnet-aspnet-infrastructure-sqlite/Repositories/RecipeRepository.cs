using dotnet_aspnet_core.IRepositories;
using dotnet_aspnet_core.Models;
using dotnet_aspnet_infrastructure.Data;

namespace dotnet_aspnet_infrastructure.Repositories;

public class RecipeRepository(SQLiteConnector sqliteConnector) : IRecipeRepository
{
    private readonly SQLiteConnector _sqliteConnector = sqliteConnector;

    public async Task<Recipe?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Recipe>> BrowseAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Create(Recipe recipe)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(Recipe recipe)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(Recipe recipe)
    {
        throw new NotImplementedException();
    }
}