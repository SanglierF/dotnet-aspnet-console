using dotnet_aspnet_console.Extensions;
using dotnet_aspnet_console.Models;

namespace dotnet_aspnet_console.Menus;

public class RecipeMenu
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
    /// <param name="cookbook">Used <see cref="Cookbook"/>.</param>
    /// <returns><see cref="bool"/> value whether program should exit completely.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown on a catastrophic error.</exception>
    internal static bool Run(Cookbook cookbook)
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
                    CreateRecipe();
                    break;
                case RecipeMenuOptions.Show:
                    ShowRecipe();
                    break;
                case RecipeMenuOptions.Remove:
                    RemoveRecipe();
                    break;
                case RecipeMenuOptions.Update:
                    UpdateRecipe();
                    break;
                case RecipeMenuOptions.Help:
                    ShowHelp();
                    break;
                case RecipeMenuOptions.List:
                    ListRecipe();
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

        void CreateRecipe()
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

                if (cookbook.Recipes.Any(recipe => recipe.Name.Equals(name)))
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

            var categories = AssignCategories();

            cookbook.Recipes.Add(
                new Recipe
                {
                    Name = name,
                    Instructions = instructions,
                    Categories = categories,
                });
            Console.WriteLine("Successfully added new recipe!");
        }

        void ShowRecipe()
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

            var foundRecipe = cookbook.Recipes.SingleOrDefault(recipe => recipe.Name.Equals(name));
            Console.WriteLine(foundRecipe == null ? "No recipe with given name!" : foundRecipe);
        }

        void RemoveRecipe()
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

            var foundRecipe = cookbook.Recipes.SingleOrDefault(recipe => recipe.Name.Equals(name));

            if (foundRecipe is null)
            {
                Console.WriteLine("No recipe with given name!");
                return;
            }

            cookbook.Recipes.Remove(foundRecipe);
            Console.WriteLine("Removed recipe!");
        }

        void UpdateRecipe()
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

            var foundRecipe = cookbook.Recipes.SingleOrDefault(recipe => recipe.Name.Equals(name));

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

                if (cookbook.Recipes.Any(recipe => recipe.Name.Equals(newName)))
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

            var categories = AssignCategories();

            foundRecipe.Name = newName;
            foundRecipe.Instructions = instructions;
            foundRecipe.Categories = categories;
            Console.WriteLine("Updated recipe!");
        }

        void ListRecipe()
        {
            if (cookbook.Recipes.Count == 0)
            {
                Console.WriteLine("No recipes!");
                return;
            }

            cookbook.Recipes.ForEach(recipe => Console.WriteLine(recipe.Name));
        }

        List<Category> AssignCategories()
        {
            List<Category> categories = new List<Category>();
            Console.WriteLine("To which categories should this recipe belong?");
            if (cookbook.Categories.Count != 0)
            {
                while (true)
                {
                    Console.WriteLine("Please input categories separated by a comma ',' fe. cake,sweet");
                    cookbook.Categories.ForEach(category => Console.Write(category + "; "));
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
                            cookbook.Categories.SingleOrDefault(category => category.Name.Equals(categoryString));
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