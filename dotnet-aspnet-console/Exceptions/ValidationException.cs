namespace dotnet_aspnet_console.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("Validation error!")
    {
    }

    public ValidationException(string message) : base(message)
    {
    }

    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}