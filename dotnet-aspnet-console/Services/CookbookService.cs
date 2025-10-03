using dotnet_aspnet_core.IRepositories;
using dotnet_aspnet_core.Models;

namespace dotnet_aspnet_console.Services;

public class CookbookService(ICookbookRepository cookbookRepository)
{
    public async Task<IEnumerable<Cookbook>> BrowseAsync()
    {
        await Task.CompletedTask;
        return await cookbookRepository.BrowseAsync();
    }

    public async Task<Cookbook?> GetAsync(Guid id)
    {
        await Task.CompletedTask;
        return await cookbookRepository.GetAsync(id);
    }

    public async Task<Guid?> CreateAsync(Cookbook cookbook)
    {
        await Task.CompletedTask;
        return await cookbookRepository.Create(cookbook);
    }

    public async Task<bool> UpdateAsync(Cookbook cookbook)
    {
        await Task.CompletedTask;
        return await cookbookRepository.Update(cookbook);
    }

    public async Task<bool> RemoveAsync(Cookbook cookbook)
    {
        await Task.CompletedTask;
        return await cookbookRepository.Delete(cookbook);
    }
}