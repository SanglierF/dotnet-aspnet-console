namespace loops;

internal static class Program
{
    static void Main()
    {
        E1();
        E2();
        E3();
        E4();
        E5();
        E6();
        E7();
        E8();
        E9();
        E10();

        Console.WriteLine("Bye.");
    }

    // Prime number checker
    private static void E1()
    {
        var primeCount = 0; // 0 and 1 are not primes
        for (int i = 2; i <= 100; i++)
        {
            bool isPrime = true;
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) primeCount++;
        }

        Console.WriteLine($"There is {primeCount} prime numbers in [0, 100] range.");
    }

    // Even number checker
    private static void E2()
    {
        var evenCount = 0;
        var i = 0;
        do
        {
            if (i % 2 == 0) evenCount++;
            i++;
        } while (i <= 1000);

        Console.WriteLine($"There is {evenCount} even numbers in [0, 1000] range.");
    }

    // Fibonacci
    private static void E3(int to = 25)
    {
        Console.WriteLine("0");
        Console.WriteLine("1");
        var n1 = 1;
        var n2 = 0;
        for (int i = 2; i <= to; i++)
        {
            var f = n1 + n2;
            n2 = n1;
            n1 = f;
            Console.WriteLine(f);
        }
    }

    // Pyramid
    private static void E4(int to = 10)
    {
        var width = 1;
        for (int i = 1; i <= to;)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(i.ToString().PadLeft(3));
                i++;
            }

            width++;
            Console.Write("\r\n");
        }
    }

    // Third power
    private static void E5(int to = 20)
    {
        for (int i = 1; i <= to; i++)
        {
            Console.WriteLine(Math.Pow(i, 3));
        }
    }

    // Sum of a series.
    private static void E6(int to = 20)
    {
        var sum = 1.0;
        for (int i = 1; i <= to; i++)
        {
            sum += 1 / ((double)i + 1);
        }

        Console.WriteLine($"Sum equals {sum}");
    }

    // Print rhombus.
    private static void E7(int width = 6)
    {
        for (int i = 1; i <= width; i++)
        {
            string message = "";
            message = message.PadLeft(width - i);
            for (int j = 0; j < i; j++)
            {
                message += "* ";
            }

            Console.WriteLine(message);
        }

        for (int i = width - 1; i >= 1; i--)
        {
            string message = "";
            message = message.PadLeft(width - i);
            for (int j = 0; j < i; j++)
            {
                message += "* ";
            }

            Console.WriteLine(message);
        }
    }

    // Reverse string.
    private static void E8()
    {
        String:
        Console.WriteLine("Please input something.");
        var input = Console.ReadLine();
        if (input is null or "")
        {
            Console.WriteLine("Please input something!");
            goto String;
        }

        for (var i = input.Length - 1; i >= 0; i--)
        {
            Console.Write(input[i]);
        }

        Console.WriteLine();
    }

    // Decimal to binary.
    private static void E9(int number = 25)
    {
        string binary = string.Empty;
        while (number > 0)
        {
            binary = number % 2 + binary;
            number /= 2;
        }

        Console.WriteLine(binary);
    }

    // Least common multiple.
    private static void E10(int first = 13, int second = 48)
    {
        Console.Write($"For numbers {first} and {second} ");
        var largerNumber = first > second ? first : second;
        for (var i = largerNumber;; i++)
        {
            if (!(i % first == 0 && i % second == 0)) continue;
            Console.WriteLine($"least common multiple is {i}.");
            return;
        }
    }
}