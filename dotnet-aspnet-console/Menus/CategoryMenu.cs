using dotnet_aspnet_console.Exceptions;
using dotnet_aspnet_console.Extensions;
using dotnet_aspnet_console.Services;
using dotnet_aspnet_core.Models;

namespace dotnet_aspnet_console.Menus;

public class CategoryMenu(
    CookbookService cookbookService,
    CategoryService categoryService,
    RecipeService recipeService)
{
    private enum CategoryOptions
    {
        Add,
        Delete,
        Edit,
        List,
        Help,
        Back,
        Exit,
    }

    /// <summary>
    /// Runs category options menu in a loop.
    /// </summary>
    /// <returns><see cref="bool"/> value whether program should exit completely.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown on a catastrophic error.</exception>
    internal async Task<bool> RunAsync()
    {
        Console.Clear();
        ShowHelp();
        while (true)
        {
            var input = Console.ReadLine();
            if (!Enum.TryParse(input.FirstCharToUpper(), out CategoryOptions inputEnum))
            {
                Console.WriteLine("Invalid options please chose one of the following!");
                ShowHelp();
                continue;
            }

            switch (inputEnum)
            {
                case CategoryOptions.Add:
                    await AddCategory();
                    break;
                case CategoryOptions.Delete:
                    await DeleteCategory();
                    break;
                case CategoryOptions.Edit:
                    await EditCategory();
                    break;
                case CategoryOptions.List:
                    await ListCategories();
                    break;
                case CategoryOptions.Help:
                    ShowHelp();
                    break;
                case CategoryOptions.Back:
                    return false;
                case CategoryOptions.Exit:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void ShowHelp()
        {
            Console.WriteLine($"{CategoryOptions.Add.ToLowerString()} - add category");
            Console.WriteLine($"{CategoryOptions.Delete.ToLowerString()} - delete category");
            Console.WriteLine($"{CategoryOptions.Edit.ToLowerString()} - edit category");
            Console.WriteLine($"{CategoryOptions.List.ToLowerString()} - show all categories");
            Console.WriteLine($"{CategoryOptions.Help.ToLowerString()} - show help");
            Console.WriteLine($"{CategoryOptions.Back.ToLowerString()} - go back");
            Console.WriteLine($"{CategoryOptions.Exit.ToLowerString()} - exit program");
        }


        async Task AddCategory()
        {
            Console.WriteLine("Please input category name");
            string? name;
            while (true)
            {
                name = Console.ReadLine();
                if (name is null or "")
                {
                    Console.WriteLine("Name can't be empty!");
                    continue;
                }

                try
                {
                    await categoryService.CreateAsync(
                        new Category
                        {
                            Name = name,
                        });
                }
                catch (ValidationException validationException)
                {
                    Console.WriteLine(validationException.Message);
                    return;
                }

                break;
            }

            Console.WriteLine("Successfully added new category!");
        }

        async Task DeleteCategory()
        {
            Console.WriteLine("Please input category name");
            string? name;
            while (true)
            {
                name = Console.ReadLine();
                if (name is null or "")
                {
                    Console.WriteLine("Name can't be empty!");
                    continue;
                }

                break;
            }

            var foundCategory = await categoryService.FindByName(name);

            if (foundCategory is null)
            {
                Console.WriteLine("No category with given name!");
                return;
            }

            await categoryService.RemoveAsync(foundCategory);
            Console.WriteLine("Removed category!");
        }

        async Task EditCategory()
        {
            Console.WriteLine("Please input category name");
            string? name;
            while (true)
            {
                name = Console.ReadLine();
                if (name is null or "")
                {
                    Console.WriteLine("Name can't be empty!");
                    continue;
                }

                break;
            }

            var foundCategory =
                (await categoryService.BrowseAsync()).SingleOrDefault(category => category.Name.Equals(name));

            if (foundCategory is null)
            {
                Console.WriteLine("No category with given name!");
                return;
            }

            Console.WriteLine("Please input category's new name");
            string? newName;
            while (true)
            {
                newName = Console.ReadLine();
                if (newName is null or "")
                {
                    Console.WriteLine("Name can't be empty!");
                    continue;
                }

                if (await categoryService.FindByName(newName) is not null)
                {
                    Console.WriteLine("Category with a given name already exists!");
                    return;
                }

                break;
            }

            foundCategory.Name = newName;
            await categoryService.UpdateAsync(foundCategory);
            Console.WriteLine("Successfully edited category!");
        }

        async Task ListCategories()
        {
            var categories = (await categoryService.BrowseAsync()).ToList();
            if (categories.Count == 0)
            {
                Console.WriteLine("No categories!");
                return;
            }

            categories.ForEach(category => Console.WriteLine(category.ToString()));
        }
    }
}