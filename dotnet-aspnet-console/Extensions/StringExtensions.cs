namespace dotnet_aspnet_console.Extensions;

public static class StringExtensions
{
    public static string FirstCharToUpper(this string? str) =>
        str switch
        {
            null => string.Empty,
            "" => string.Empty,
            _ => string.Concat(str[0].ToString().ToUpper(), str.AsSpan(1))
        };

    public static bool IsNullOrEmpty(this string? str) => string.IsNullOrEmpty(str);
}