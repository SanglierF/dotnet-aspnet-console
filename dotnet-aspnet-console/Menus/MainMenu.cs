using dotnet_aspnet_console.Extensions;

namespace dotnet_aspnet_console.Menus;

internal static class MainMenu
{
    private enum MainMenuOptions
    {
        Recipes,
        Categories,
        Help,
        Exit,
    }

    internal static void Run(Cookbook cookbook)
    {
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
                    if (RecipeMenu.Run(cookbook)) goto Exit;
                    Console.Clear();
                    ShowHelp();
                    break;
                case MainMenuOptions.Categories:
                    if (CategoryMenu.Run(cookbook)) goto Exit;
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
        return;

        void ShowHelp()
        {
            Console.WriteLine($"{MainMenuOptions.Recipes.ToLowerString()} - manage recipes");
            Console.WriteLine($"{MainMenuOptions.Categories.ToLowerString()} - manage categories");
            Console.WriteLine($"{MainMenuOptions.Help.ToLowerString()} - show help");
            Console.WriteLine($"{MainMenuOptions.Exit.ToLowerString()} - exit program");
        }
    }
}