namespace TennisCourt.Features.Users.Models;

public class CreateUserRequest
{
    public string Name { get; set; } = String.Empty;
    public string Telephone { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
}