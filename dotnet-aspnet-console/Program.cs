using dotnet_aspnet_console.Menus;

namespace dotnet_aspnet_console;

//Książka kucharska
internal static class Program
{
    internal static void Main()
    {
        Console.WriteLine("Welcome to your own cooking book!");
        Console.WriteLine("What do you want to do?");
        var cookbook = new Cookbook();
        Console.CancelKeyPress += delegate { Exit(); };
        MainMenu.Run(cookbook);
        return;

        void Exit()
        {
            Console.WriteLine("Bye :(");
        }
    }
}