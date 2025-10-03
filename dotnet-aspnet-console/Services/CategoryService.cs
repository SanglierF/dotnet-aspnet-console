using dotnet_aspnet_console.Exceptions;
using dotnet_aspnet_core.IRepositories;
using dotnet_aspnet_core.Models;

namespace dotnet_aspnet_console.Services;

public class CategoryService(ICategoryRepository categoryRepository, IRecipeRepository recipeRepository)
{
    public async Task<IEnumerable<Category>> BrowseAsync()
    {
        await Task.CompletedTask;
        return await categoryRepository.BrowseAsync();
    }

    public async Task<Category?> GetAsync(Guid id)
    {
        await Task.CompletedTask;
        return await categoryRepository.GetAsync(id);
    }

    public async Task<Category?> FindByName(string name)
    {
        return (await categoryRepository.BrowseAsync()).FirstOrDefault(r => r.Name == name);
    }

    public async Task<Guid> CreateAsync(Category category)
    {
        if ((await categoryRepository.BrowseAsync()).Any(cat => cat.Name.Equals(category.Name)))
        {
            throw new ValidationException("Category with a given name already exists!");
        }

        return await categoryRepository.Create(category);
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        await Task.CompletedTask;
        return await categoryRepository.Update(category);
    }

    public async Task<bool> RemoveAsync(Category category)
    {
        var recipesWithCategory =
            (await recipeRepository.BrowseAsync()).Where(recipe =>
                recipe.Categories.Any(c => c.Id.Equals(category.Id)));
        foreach (var recipe in recipesWithCategory)
        {
            recipe.Categories = recipe.Categories.Where(c => !c.Id.Equals(category.Id))
                                      .ToList();
            await recipeRepository.Update(recipe);
        }

        return await categoryRepository.Delete(category);
    }
}