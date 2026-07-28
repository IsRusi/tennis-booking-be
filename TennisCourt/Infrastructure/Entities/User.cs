namespace TennisCourt.Infrastructure.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Telephone { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Role { get; set; } = String.Empty;

}