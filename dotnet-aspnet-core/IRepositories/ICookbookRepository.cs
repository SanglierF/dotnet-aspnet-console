using dotnet_aspnet_core.Models;

namespace dotnet_aspnet_core.IRepositories;

public interface ICookbookRepository
{
    public Task<Cookbook?> GetAsync(Guid id);

    public Task<IEnumerable<Cookbook>> BrowseAsync();

    public Task<Guid> Create(Cookbook cookbook);

    public Task<bool> Update(Cookbook cookbook);

    public Task<bool> Delete(Cookbook cookbook);
}