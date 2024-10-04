namespace dotnet_aspnet_console.Models;

public class Category
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;

    public override string ToString()
    {
        return Name;
    }
}