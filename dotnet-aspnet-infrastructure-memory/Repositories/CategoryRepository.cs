using dotnet_aspnet_core.IRepositories;
using dotnet_aspnet_core.Models;
using dotnet_aspnet_infrastructure_memory.Data;

namespace dotnet_aspnet_infrastructure_memory.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly MContext _mContext;

    public CategoryRepository(MContext mContext)
    {
        _mContext = mContext;
    }

    public async Task<Category?> GetAsync(Guid id)
    {
        await Task.CompletedTask;
        return (Category?)_mContext.Categories.Find(category => category.Id.Equals(id))?.Clone();
    }

    public async Task<IEnumerable<Category>> BrowseAsync()
    {
        await Task.CompletedTask;
        return _mContext.Categories.Select(cb => (Category)cb.Clone()).AsEnumerable();
    }

    public async Task<Guid> Create(Category category)
    {
        await Task.CompletedTask;
        _mContext.Categories.Add((Category)category.Clone());
        return category.Id;
    }

    public async Task<bool> Update(Category category)
    {
        await Task.CompletedTask;
        var updatedCategory = _mContext.Categories.Find(cb => cb.Id.Equals(category.Id));
        if (updatedCategory == null) return false;
        updatedCategory.Name = category.Name;
        return true;
    }

    public async Task<bool> Delete(Category category)
    {
        await Task.CompletedTask;
        var categoryIndex = _mContext.Categories.FindIndex(cb => cb.Id.Equals(category.Id));
        if (categoryIndex == -1) return false;
        _mContext.Categories.RemoveAt(categoryIndex);
        return true;
    }
}