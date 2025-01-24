using dotnet_aspnet_core.Models;

namespace dotnet_aspnet_core.IRepositories;

public interface ICategoryRepository
{
    public Task<Category?> GetAsync(Guid id);

    public Task<IEnumerable<Category>> BrowseAsync();

    public Task<Guid> Create(Category category);

    public Task<bool> Update(Category category);

    public Task<bool> Delete(Category category);
}