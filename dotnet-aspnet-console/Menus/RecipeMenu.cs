using dotnet_aspnet_console.Extensions;
using dotnet_aspnet_console.Services;
using dotnet_aspnet_core.Models;

namespace dotnet_aspnet_console.Menus;

using dotnet_aspnet_console.Exceptions;

public class RecipeMenu(
    CookbookService cookbookService,
    CategoryService categoryService,
    RecipeService recipeService)
{
    private enum RecipeMenuOptions
    {
        Create,
        Show,
        Remove,
        Update,
        List,
        Help,
        Back,
        Exit,
    }

    /// <summary>
    /// Runs recipe options menu in a loop.
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
            if (!Enum.TryParse(input.FirstCharToUpper(), out RecipeMenuOptions inputEnum))
            {
                Console.WriteLine("Invalid options please chose one of the following!");
                ShowHelp();
                continue;
            }

            switch (inputEnum)
            {
                case RecipeMenuOptions.Create:
                    await CreateRecipe();
                    break;
                case RecipeMenuOptions.Show:
                    await ShowRecipe();
                    break;
                case RecipeMenuOptions.Remove:
                    await RemoveRecipe();
                    break;
                case RecipeMenuOptions.Update:
                    await UpdateRecipe();
                    break;
                case RecipeMenuOptions.Help:
                    ShowHelp();
                    break;
                case RecipeMenuOptions.List:
                    await ListRecipe();
                    break;
                case RecipeMenuOptions.Back:
                    return false;
                case RecipeMenuOptions.Exit:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void ShowHelp()
        {
            Console.WriteLine($"{RecipeMenuOptions.Create.ToLowerString()} - create recipe");
            Console.WriteLine($"{RecipeMenuOptions.Show.ToLowerString()} - show recipe");
            Console.WriteLine($"{RecipeMenuOptions.Remove.ToLowerString()} - remove recipe");
            Console.WriteLine($"{RecipeMenuOptions.Update.ToLowerString()} - update recipe");
            Console.WriteLine($"{RecipeMenuOptions.List.ToLowerString()} - show all recipes");
            Console.WriteLine($"{RecipeMenuOptions.Help.ToLowerString()} - show help");
            Console.WriteLine($"{RecipeMenuOptions.Back.ToLowerString()} - go back");
            Console.WriteLine($"{RecipeMenuOptions.Exit.ToLowerString()} - exit program");
        }

        async Task CreateRecipe()
        {
            Console.WriteLine("Please input recipe name");
            string? name;
            while (true)
            {
                name = Console.ReadLine();
                if (name is null or "")
                {
                    Console.WriteLine("Name can't be empty!");
                    continue;
                }

                if ((await recipeService.BrowseAsync()).Any(recipe => recipe.Name.Equals(name)))
                {
                    Console.WriteLine("Recipe with a given name already exists!");
                    return;
                }

                break;
            }

            Console.WriteLine("Please input recipe instructions");
            string? instructions;
            while (true)
            {
                instructions = Console.ReadLine();
                if (instructions is null or "")
                {
                    Console.WriteLine("Instructions can't be empty!");
                    continue;
                }

                break;
            }

            var categories = await AssignCategories();

            try
            {
                await recipeService.CreateAsync(
                    new Recipe
                    {
                        Name = name,
                        Instructions = instructions,
                        Categories = categories,
                    });
            }
            catch (ValidationException validationException)
            {
                Console.WriteLine(validationException.Message);
                return;
            }


            Console.WriteLine("Successfully added new recipe!");
        }

        async Task ShowRecipe()
        {
            Console.WriteLine("Please input recipe name");
            string? name;
            while (true)
            {
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name can't be empty!");
                    continue;
                }

                break;
            }

            var foundRecipe = await recipeService.FindByName(name);
            Console.WriteLine(
                foundRecipe == null ?
                    "No recipe with given name!" :
                    foundRecipe);
        }

        async Task RemoveRecipe()
        {
            Console.WriteLine("Please input recipe name");
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

            var foundRecipe = await recipeService.FindByName(name);

            if (foundRecipe is null)
            {
                Console.WriteLine("No recipe with given name!");
                return;
            }

            await recipeService.RemoveAsync(foundRecipe);
            Console.WriteLine("Removed recipe!");
        }

        async Task UpdateRecipe()
        {
            Console.WriteLine("Please input recipe name");
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

            var foundRecipe = await recipeService.FindByName(name);

            if (foundRecipe is null)
            {
                Console.WriteLine("No recipe with given name!");
                return;
            }

            Console.WriteLine("Please input recipe's new name or press enter to skip name change");
            string? newName;
            while (true)
            {
                newName = Console.ReadLine();
                if (newName is null or "")
                {
                    newName = foundRecipe.Name;
                    break;
                }

                if (await recipeService.FindByName(newName) is not null)
                {
                    Console.WriteLine("Recipe with a given name already exists!");
                    return;
                }

                break;
            }

            string? instructions;
            Console.WriteLine("Please input recipe's new instructions or press enter to skip instruction change");
            while (true)
            {
                instructions = Console.ReadLine();
                if (instructions is null or "")
                {
                    instructions = foundRecipe.Instructions;
                }

                break;
            }

            var categories = await AssignCategories();

            foundRecipe.Name = newName;
            foundRecipe.Instructions = instructions;
            foundRecipe.Categories = categories;
            await recipeService.UpdateAsync(foundRecipe);
            Console.WriteLine("Updated recipe!");
        }

        async Task ListRecipe()
        {
            var recipes = (await recipeService.BrowseAsync()).ToList();
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes!");
                return;
            }

            recipes.ForEach(recipe => Console.WriteLine(recipe.Name));
        }

        async Task<List<Category>> AssignCategories()
        {
            List<Category> categories = new List<Category>();
            Console.WriteLine("To which categories should this recipe belong?");
            var allCategories = (await categoryService.BrowseAsync()).ToList();
            if (allCategories.Count != 0)
            {
                while (true)
                {
                    Console.WriteLine("Please input categories separated by a comma ',' fe. cake,sweet");
                    allCategories.ForEach(category => Console.Write(category + "; "));
                    Console.WriteLine();
                    var inputCategories = Console.ReadLine();
                    if (inputCategories is null or "")
                    {
                        Console.WriteLine("No category assigned - ok!");
                        return categories;
                    }

                    var categoriesStrings = inputCategories.Split(',');
                    foreach (var categoryString in categoriesStrings)
                    {
                        var foundCategory =
                            allCategories.SingleOrDefault(category => category.Name.Equals(categoryString));
                        if (foundCategory is not null)
                        {
                            categories.Add(foundCategory);
                            continue;
                        }

                        Console.WriteLine($"{categoryString} doesn't exist!");
                        categories.Clear();
                        break;
                    }

                    if (categories.Count == 0) continue;
                    break;
                }
            }

            return categories;
        }
    }
}