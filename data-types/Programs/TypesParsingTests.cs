namespace data_types.Programs;

public static class TypesParsingTests
{
    public static int Run()
    {
        string? firstName = string.Empty;
        while (firstName is null or "")
        {
            Console.WriteLine("Please input your first name!");
            firstName = Console.ReadLine();
            if (firstName is not null or not "")
            {
                Console.WriteLine($"Your first name is {firstName}");
            }
        }

        string? lastName = string.Empty;
        while (lastName is null or "")
        {
            Console.WriteLine("Please input your last name!");
            lastName = Console.ReadLine();
            if (lastName is not null or not "")
            {
                Console.WriteLine($"Your last name is {lastName}");
            }
        }

        int age = 0;
        while (age <= 0)
        {
            Console.WriteLine("Please input your age as a whole number.");
            var input = Console.ReadLine();
            var isValidInput = int.TryParse(input, out age);
            if (!isValidInput)
            {
                Console.WriteLine("Please input a valid integer!");
            }
            else if (age <= 0)
            {
                Console.WriteLine("You must have been born already come on!");
            }
            else
            {
                Console.WriteLine($"Your age is {age}");
            }
        }

        float weight = 0.0f;
        while (weight <= 0)
        {
            Console.WriteLine("Please input your weight in kg. e.g. 65.2");
            var input = Console.ReadLine();
            var isValidInput = float.TryParse(input, out weight);
            if (!isValidInput)
            {
                Console.WriteLine("Please input a valid weight!");
            }
            else if (weight <= 0)
            {
                Console.WriteLine("Your weight can't be negative!");
            }
            else
            {
                Console.WriteLine($"Your weight is {weight}");
            }
        }

        decimal money = 0.00m;
        while (money <= 0)
        {
            Console.WriteLine("Please input how much money you have in your wallet.");
            var input = Console.ReadLine();
            var isValidInput = decimal.TryParse(input, out money);
            if (!isValidInput)
            {
                Console.WriteLine("Please input a valid amount!");
            }
            else if (money < 0)
            {
                Console.WriteLine("You can't have negative money!");
            }
            else
            {
                Console.WriteLine($"Your money is {money}");
            }
        }

        double height = 0.0;
        while (height <= 0)
        {
            Console.WriteLine("Please input how tall you are in meters. // e.g. 1.69");
            var input = Console.ReadLine();
            var isValidInput = double.TryParse(input, out height);
            if (!isValidInput)
            {
                Console.WriteLine("Please input a valid height!");
            }
            else if (height < 0)
            {
                Console.WriteLine("You can't have negative height!");
            }
            else
            {
                Console.WriteLine($"Your height is {height}");
            }
        }

        char nationality = 'i';
        while (!nationality.Equals('y') && !nationality.Equals('n'))
        {
            Console.WriteLine("Are you Polish? Please write either \"y\" or \"n\".");
            var input = Console.ReadLine();
            var isValidInput = char.TryParse(input, out nationality);
            if (!isValidInput)
            {
                Console.WriteLine("Please answer with a single character!");
            }
            else if (!nationality.Equals('y') && !nationality.Equals('n'))
            {
                Console.WriteLine("You can only answer either \"y\" or \"n\".");
            }
            else if (nationality.Equals('y'))
            {
                Console.WriteLine($"You are Polish");
            }
            else
            {
                Console.WriteLine($"You are not Polish");
            }
        }

        bool isHappy;
        bool isInputValid = false;
        while (!isInputValid)
        {
            Console.WriteLine("Are you happy?! True or False.");
            var input = Console.ReadLine();
            isInputValid = bool.TryParse(input, out isHappy);
            if (!isInputValid)
            {
                Console.WriteLine("Please answer true or false!");
            }
            else if (isHappy)
            {
                Console.WriteLine("You are happy! YAY!");
            }
            else
            {
                Console.WriteLine("Big sad... :(");
            }
        }

        return 0;
    }
}