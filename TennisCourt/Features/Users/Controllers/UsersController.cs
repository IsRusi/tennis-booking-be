using Microsoft.AspNetCore.Mvc;
using TennisCourt.Features.Users.Models;
using TennisCourt.Features.Users.Services;

namespace TennisCourt.Features.Users.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUsersService usersService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest createUserRequest, CancellationToken cancellationToken = default)
    {
        try
        {
            var id = await usersService.CreateAsync(new UserDto()
            {
                Email = createUserRequest.Email,
                Telephone = createUserRequest.Telephone,
                Name = createUserRequest.Name
            }, cancellationToken);
            return Ok(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await usersService.GetByIdAsync(id, cancellationToken);

            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}