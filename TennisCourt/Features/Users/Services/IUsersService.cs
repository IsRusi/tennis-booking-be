using TennisCourt.Features.Users.Models;

namespace TennisCourt.Features.Users.Services;

public interface IUsersService
{
    public Task<Guid> CreateAsync(UserDto user, CancellationToken cancellationToken = default);
    public Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}