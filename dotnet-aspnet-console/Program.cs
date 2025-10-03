using dotnet_aspnet_console.Menus;
using dotnet_aspnet_console.Services;
using dotnet_aspnet_core.Models;
using dotnet_aspnet_infrastructure_memory.Data;
using dotnet_aspnet_infrastructure_memory.Repositories;

namespace dotnet_aspnet_console;

//Książka kucharska
internal static class Program
{
    internal static async Task Main()
    {
        Console.WriteLine("Welcome to your own cooking book!");
        Console.WriteLine("What do you want to do?");
        var context = new MContext();

        var cookbookRepository = new CookbookRepository(context);
        var categoriesRepository = new CategoryRepository(context);
        var recipesRepository = new RecipeRepository(context);
        var cookbookService = new CookbookService(cookbookRepository);
        var categoriesService = new CategoryService(categoriesRepository, recipesRepository);
        var recipesService = new RecipeService(recipesRepository);
        var id = await cookbookRepository.Create(new Cookbook());
        var cookbook = await cookbookRepository.GetAsync(id);
        if (cookbook == null)
        {
            Console.WriteLine("Catastrophic failure!");
            return;
        }

        Console.CancelKeyPress += delegate { Exit(); };
        await new MainMenu(cookbookService, categoriesService, recipesService).RunAsync();
        return;

        void Exit()
        {
            Console.WriteLine("Bye :(");
        }
    }
}