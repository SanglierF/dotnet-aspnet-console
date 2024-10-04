namespace dotnet_aspnet_console.Extensions;

public static class EnumExtensions
{
    public static string ToLowerString(this Enum enumerator)
    {
        return enumerator.ToString().ToLower();
    }
}