namespace dotnet_aspnet_console;

//Książka kucharska
class Program
{
    private static readonly string[] Options = ["add", "list", "remove", "help", "exit"];

    static int Main(string[] args)
    {
        var isRunning = true;

        void ShowMenu()
        {
            Console.WriteLine("add - add new chapter");
            Console.WriteLine("list - list chapters");
            Console.WriteLine("remove - remove a chapter chapters");
            Console.WriteLine("help - show this list");
            Console.WriteLine("exit - exit program");
        }

        Console.WriteLine("Welcome to your own cooking book!");
        Console.WriteLine("What do you want to do?");
        ShowMenu();
        while (isRunning)
        {
            var input = Console.ReadLine();
            if (Options.Contains(input?.ToLower()))
            {
                Console.WriteLine($"You chose {input}");
            }
            else
            {
                Console.WriteLine("Invalid options please chose one of the following!");
                ShowMenu();
                continue;
            }

            if (input?.ToLower().Equals("add") ?? false)
            {
                var pageNumber = -1;
                Console.WriteLine("Please give a page number");
                while (pageNumber < 0)
                {
                    input = Console.ReadLine();
                    var isSuccessfull = int.TryParse(input, out pageNumber);
                    if (!isSuccessfull || pageNumber < 0)
                    {
                        Console.WriteLine("Number must be more integer more than 0");
                    }
                }

                Console.WriteLine($"Great you wrote {pageNumber}");
                continue;
            }

            if (input?.ToLower().Equals("help") ?? false)
            {
                ShowMenu();
                continue;
            }

            if (!(input?.ToLower().Equals("exit") ?? false)) continue;
            isRunning = false;
            Console.WriteLine("bye bye!");
        }

        return 0;
    }
}