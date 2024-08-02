using data_types.Programs;

namespace data_types;

class Program
{
    static int Main(string[] args)
    {
        EmployeeData.Run();
        CharReversal.Run();
        RectangleDiagonal.Run();
        Variables.Run();
        TypesParsingTests.Run();

        return 0;
    }
}