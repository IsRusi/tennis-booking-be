namespace TennisCourt.Features.Users.Models;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}