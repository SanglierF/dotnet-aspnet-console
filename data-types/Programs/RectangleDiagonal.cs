namespace data_types.Programs;

public static class RectangleDiagonal
{
    public static int Run()
    {
        int length = 0;
        int width = 0;

        Console.WriteLine("Let's calculate rectangle's diagonal!");
        while (length <= 0)
        {
            Console.WriteLine("Please input length of the rectangle. //Has to be more than 0!");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out length) || length <= 0)
            {
                Console.WriteLine("Rectangle length can't be less than 0!");
            }
        }

        while (width <= 0)
        {
            Console.WriteLine("Please input width of the rectangle. //Has to be more than 0!");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out width) || width <= 0)
            {
                Console.WriteLine("Rectangle width can't be less than 0!");
            }
        }

        Console.WriteLine($"Rectangle diagonal is {Math.Sqrt(Math.Pow(length, 2) + Math.Pow(width, 2))}");

        return 0;
    }
}