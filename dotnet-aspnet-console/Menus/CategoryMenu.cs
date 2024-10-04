using dotnet_aspnet_console.Extensions;
using dotnet_aspnet_console.Models;

namespace dotnet_aspnet_console.Menus;

public class CategoryMenu
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
    /// <param name="cookbook">Used <see cref="Cookbook"/>.</param>
    /// <returns><see cref="bool"/> value whether program should exit completely.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown on a catastrophic error.</exception>
    internal static bool Run(Cookbook cookbook)
    {
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
                    AddCategory();
                    break;
                case CategoryOptions.Delete:
                    DeleteCategory();
                    break;
                case CategoryOptions.Edit:
                    EditCategory();
                    break;
                case CategoryOptions.List:
                    ListCategories();
                    break;
                case CategoryOptions.Help:
                    ShowHelp();
                    break;
                case CategoryOptions.Back:
                    goto Back;
                case CategoryOptions.Exit:
                    goto Exit;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        Back:
        return false;

        Exit:
        return true;

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


        void AddCategory()
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

                if (cookbook.Categories.Any(category => category.Name.Equals(name)))
                {
                    Console.WriteLine("category with a given name already exists!");
                    return;
                }

                break;
            }

            cookbook.Categories.Add(
                new Category
                {
                    Name = name,
                });
            Console.WriteLine("Successfully added new category!");
        }

        void DeleteCategory()
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

            var foundCategory = cookbook.Categories.SingleOrDefault(category => category.Name.Equals(name));

            if (foundCategory is null)
            {
                Console.WriteLine("No category with given name!");
                return;
            }

            cookbook.Recipes.ForEach(recipe => recipe.Categories.Remove(foundCategory));
            cookbook.Categories.Remove(foundCategory);
            Console.WriteLine("Removed category!");
        }

        void EditCategory()
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

            var foundcategory = cookbook.Categories.SingleOrDefault(category => category.Name.Equals(name));

            if (foundcategory is null)
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

                if (cookbook.Categories.Any(category => category.Name.Equals(newName)))
                {
                    Console.WriteLine("category with a given name already exists!");
                    return;
                }

                break;
            }

            foundcategory.Name = newName;
            Console.WriteLine("Successfully edited category!");
        }

        void ListCategories()
        {
            if (cookbook.Categories.Count == 0)
            {
                Console.WriteLine("No categories!");
                return;
            }

            cookbook.Categories.ForEach(category => Console.WriteLine(category.ToString()));
        }
    }
}