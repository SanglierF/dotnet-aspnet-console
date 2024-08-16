namespace conditions;

internal static class Program
{
    static void Main()
    {
        E1(5, 5);
        E2();
        E3();
        E4();
        E5();
        E6();
        E7();
        E8();
        E9();
        E10();
        E11();
        E12();
        E13();
        Console.WriteLine("Bye.");
    }

    // Are integers equal?
    private static void E1(int a = 3, int b = 4)
    {
        Console.WriteLine(a == b ? $"{a} and {b} are equal." : $"{a} and {b} are not equal.");
    }

    // Is integer odd or even?
    private static void E2()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Please input an integer.");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var parsed))
            {
                isRunning = false;
                Console.WriteLine(parsed % 2 == 0 ? $"{parsed} is even." : $"{parsed} is odd.");
            }
            else
            {
                Console.WriteLine("Not an integer!");
            }
        }
    }

    // Is integer negative or positive?
    private static void E3()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Please input an integer.");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var parsed))
            {
                isRunning = false;
                if (parsed == 0)
                {
                    Console.WriteLine($"{parsed} is a zero!");
                    break;
                }

                Console.WriteLine(parsed > 0 ? $"{parsed} is a positive." : $"{parsed} is negative.");
            }
            else
            {
                Console.WriteLine("Not an integer!");
            }
        }
    }

    // Is a year a leap year?
    private static void E4()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Please input a year. //Has to be an integer and more than 0");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var parsed) && parsed > 0)
            {
                isRunning = false;
                if (parsed % 100 == 0)
                {
                    Console.WriteLine(
                        parsed % 400 == 0 ? $"{parsed} is a leap year." : $"{parsed} is NOT a leap year.");
                }
                else
                {
                    Console.WriteLine(parsed % 4 == 0 ? $"{parsed} is a leap year." : $"{parsed} is NOT a leap year.");
                }
            }
            else
            {
                if (parsed <= 0)
                {
                    Console.WriteLine("Can't be a zero or less!");
                    continue;
                }

                Console.WriteLine("Not an integer!");
            }
        }
    }

    // Check if a person with given age is eligible to be a Polish politician?
    private static void E5()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Please input a person age. //Has to be an integer and more than 0");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var parsed) && parsed > 0)
            {
                isRunning = false;
                if (parsed > 35)
                {
                    Console.WriteLine("Can be a president.");
                }

                if (parsed > 30)
                {
                    Console.WriteLine("Can be a senator.");
                }

                if (parsed > 21)
                {
                    Console.WriteLine("Can be a prime minister.");
                    Console.WriteLine("Can be a member of parliament.");
                }
            }
            else
            {
                if (parsed <= 0)
                {
                    Console.WriteLine("Can't be a zero or less!");
                    continue;
                }

                Console.WriteLine("Not an integer!");
            }
        }
    }

    // Check if a person with given age is eligible to be a Polish politician?
    private static void E6()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Please input your height. //Has to be an integer and more than 0");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var parsed) && parsed > 0)
            {
                isRunning = false;
                switch (parsed)
                {
                    case > 240:
                        Console.WriteLine("You are a giant.");
                        break;
                    case > 200:
                        Console.WriteLine("You are a extremely tall.");
                        break;
                    case > 180:
                        Console.WriteLine("You are tall.");
                        break;
                    case > 160:
                        Console.WriteLine("You are average.");
                        break;
                    case > 140:
                        Console.WriteLine("You are small.");
                        break;
                    default:
                        Console.WriteLine("You are a dwarf.");
                        break;
                }
            }
            else
            {
                if (parsed <= 0)
                {
                    Console.WriteLine("Can't be a zero or less!");
                    continue;
                }

                Console.WriteLine("Not an integer!");
            }
        }
    }

    // Check which number is greater?
    private static void E7()
    {
        string? input;

        RetryInputFirstNumber:
        Console.WriteLine("Please input first number. //Has to be an integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var parsed1))
        {
            Console.WriteLine("Not an integer!");
            goto RetryInputFirstNumber;
        }

        RetryInputSecondNumber:
        Console.WriteLine("Please input second number. //Has to be an integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var parsed2))
        {
            Console.WriteLine("Not an integer!");
            goto RetryInputSecondNumber;
        }

        RetryInputThirdNumber:
        Console.WriteLine("Please input third number. //Has to be an integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var parsed3))
        {
            Console.WriteLine("Not an integer!");
            goto RetryInputThirdNumber;
        }

        if (parsed1 > parsed2 && parsed1 > parsed3)
        {
            Console.WriteLine($"{parsed1} is the biggest number.");
        }
        else if (parsed2 > parsed1 && parsed2 > parsed3)
        {
            Console.WriteLine($"{parsed2} is the biggest number.");
        }
        else if (parsed3 > parsed1 && parsed3 > parsed2)
        {
            Console.WriteLine($"{parsed3} is the biggest number.");
        }
    }

    // Check if result's score are good enough for college admission?
    private static void E8()
    {
        string? input;

        RetryInputMathScore:
        Console.WriteLine("Please input Math exam score. //Has to be a non-negative integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var mathScore) || mathScore < 0)
        {
            Console.WriteLine("Input must be an integer and a positive number!");
            goto RetryInputMathScore;
        }

        RetryInputPhysicsScore:
        Console.WriteLine("Please input Physics exam score. //Has to be a non-negative integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var physicsScore) || physicsScore < 0)
        {
            Console.WriteLine("Input must be an integer and a positive number!");
            goto RetryInputPhysicsScore;
        }

        RetryInputChemistryScore:
        Console.WriteLine("Please input Chemistry exam score. //Has to be a non-negative integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var chemistryScore) || chemistryScore < 0)
        {
            Console.WriteLine("Input must be an integer and a positive number!");
            goto RetryInputChemistryScore;
        }

        if (mathScore <= 70 || physicsScore <= 55 || chemistryScore <= 45)
        {
            Console.WriteLine("Results NOT good enough for admission.");
            return;
        }

        if (mathScore + physicsScore + chemistryScore < 180 &&
            mathScore + physicsScore < 150 &&
            mathScore + chemistryScore < 150)
        {
            Console.WriteLine("Results NOT good enough for admission.");
        }

        Console.WriteLine("Results are good enough for recruitment.");
    }

    // Check temperature.
    private static void E9()
    {
        string? input;

        RetryInputTemperature:
        Console.WriteLine("Please input current temperature. //Has to be an integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var temperature))
        {
            Console.WriteLine("Input must be an integer!");
            goto RetryInputTemperature;
        }

        var message = temperature switch
        {
            < 0 => "cholernie piździ",
            < 10 => "zimno",
            < 20 => "chłodno",
            < 30 => "w sam raz",
            < 40 => "zaczyna być słabo, bo gorąco",
            _ => "a weź wyprowadzam się na Alaskę."
        };

        Console.WriteLine(message);
    }

    // Check if you can create a triangle from given sides.
    private static void E10()
    {
        string? input;

        RetryInputSideA:
        Console.WriteLine("Please input first side of triangle. //Has to be a positive integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var sideA) || sideA <= 0)
        {
            Console.WriteLine("Input must be a positive integer!");
            goto RetryInputSideA;
        }

        RetryInputSideB:
        Console.WriteLine("Please input second side of triangle. //Has to be a positive integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var sideB) || sideB <= 0)
        {
            Console.WriteLine("Input must be a positive integer!");
            goto RetryInputSideB;
        }

        RetryInputSideC:
        Console.WriteLine("Please input third side of triangle. //Has to be a positive integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var sideC) || sideC <= 0)
        {
            Console.WriteLine("Input must be a positive integer!");
            goto RetryInputSideC;
        }

        if ((sideA > sideB && sideA > sideC && sideA < sideB + sideC) ||
            (sideB > sideA && sideB > sideC && sideB < sideA + sideC) ||
            (sideC > sideA && sideC > sideB && sideC < sideA + sideB))
        {
            Console.WriteLine("Can make a triangle from these sides.");
            return;
        }

        Console.WriteLine("Can't make a triangle from these sides.");
    }

    // Print student's score.
    private static void E11()
    {
        string? input;

        RetryInputScore:
        Console.WriteLine("Please input student's score in [1-6] range. //Has to be a positive integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var score) || score < 1 || score > 6)
        {
            Console.WriteLine("Input must be a positive integer in [1-6] range!");
            goto RetryInputScore;
        }

        var message = score switch
        {
            6 => "Celujący",
            5 => "Bardzo dobry",
            4 => "Dobry",
            3 => "Dostateczny",
            2 => "Dopuszczający",
            1 => "Niedostateczny",
            _ => throw new ArgumentOutOfRangeException()
        };

        Console.WriteLine(message);
    }

    // Print weekday.
    private static void E12()
    {
        string? input;

        RetryInputDayOfWeek:
        Console.WriteLine("Please input day of the week score in [1-7] range. //Has to be a positive integer");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var dayOfWeek) || dayOfWeek < 1 || dayOfWeek > 7)
        {
            Console.WriteLine("Input must be a positive integer in [1-7] range!");
            goto RetryInputDayOfWeek;
        }

        var message = dayOfWeek switch
        {
            7 => "Sunday",
            6 => "Saturday",
            5 => "Friday",
            4 => "Thursday",
            3 => "Wednesday",
            2 => "Tuesday",
            1 => "Monday",
            _ => throw new ArgumentOutOfRangeException()
        };

        Console.WriteLine(message);
    }

    // Calculator.
    private static void E13()
    {
        string? input;

        RetryInputFirstNumber:
        Console.WriteLine("Please input first number.");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var firstNumber))
        {
            Console.WriteLine("Input must be an integer!");
            goto RetryInputFirstNumber;
        }

        RetryInputSecondNumber:
        Console.WriteLine("Please input second number.");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var secondNumber))
        {
            Console.WriteLine("Input must be an integer!");
            goto RetryInputSecondNumber;
        }

        RetryInputOption:
        Console.WriteLine("Please input what calculation you want to do.");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide.");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var option) || option < 1 || option > 4)
        {
            Console.WriteLine("Input must be an integer in range [1, 4]!");
            goto RetryInputOption;
        }

        switch (option)
        {
            case 1:
                Console.WriteLine($"Result: {firstNumber + secondNumber}");
                break;
            case 2:
                Console.WriteLine($"Result: {firstNumber - secondNumber}");
                break;
            case 3:
                Console.WriteLine($"Result: {firstNumber * secondNumber}");
                break;
            case 4 when secondNumber == 0:
                Console.WriteLine("You can't divide by zero!");
                break;
            case 4 when firstNumber % secondNumber == 0:
                Console.WriteLine($"Result: {firstNumber / secondNumber}");
                break;
            case 4:
                Console.WriteLine(
                    $"Result: {firstNumber / secondNumber} with a {firstNumber % secondNumber} remainder");
                break;
        }
    }
}