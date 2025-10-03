using dotnet_aspnet_console.Extensions;
using dotnet_aspnet_console.Services;
using dotnet_aspnet_core.Models;

namespace dotnet_aspnet_console.Menus;

internal class MainMenu(
    CookbookService cookbookService,
    CategoryService categoryService,
    RecipeService recipeService)
{
    private enum MainMenuOptions
    {
        Recipes,
        Categories,
        Help,
        Exit,
    }

    /// <summary>
    /// Runs main options menu in a loop.
    /// </summary>
    /// <returns><see cref="bool"/> value whether program should exit completely.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown on a catastrophic error.</exception>
    internal async Task<bool> RunAsync()
    {
        var recipeMenu = new RecipeMenu(cookbookService, categoryService, recipeService);
        var categoryMenu = new CategoryMenu(cookbookService, categoryService, recipeService);
        ShowHelp();
        while (true)
        {
            var input = Console.ReadLine();
            if (!Enum.TryParse(input.FirstCharToUpper(), out MainMenuOptions inputEnum))
            {
                Console.WriteLine("Invalid options please chose one of the following!");
                ShowHelp();
                continue;
            }

            switch (inputEnum)
            {
                case MainMenuOptions.Recipes:
                    if (await recipeMenu.RunAsync()) goto Exit;
                    Console.Clear();
                    ShowHelp();
                    break;
                case MainMenuOptions.Categories:
                    if (await categoryMenu.RunAsync()) goto Exit;
                    Console.Clear();
                    ShowHelp();
                    break;
                case MainMenuOptions.Help:
                    ShowHelp();
                    break;
                case MainMenuOptions.Exit:
                    goto Exit;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        Exit:
        Console.WriteLine("bye bye!");
        return true;

        void ShowHelp()
        {
            Console.WriteLine($"{MainMenuOptions.Recipes.ToLowerString()} - manage recipes");
            Console.WriteLine($"{MainMenuOptions.Categories.ToLowerString()} - manage categories");
            Console.WriteLine($"{MainMenuOptions.Help.ToLowerString()} - show help");
            Console.WriteLine($"{MainMenuOptions.Exit.ToLowerString()} - exit program");
        }
    }
}