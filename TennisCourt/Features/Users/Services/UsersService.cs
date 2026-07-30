using TennisCourt.Features.Users.Data;
using TennisCourt.Features.Users.Models;
using TennisCourt.Infrastructure.Constants;
using TennisCourt.Infrastructure.Entities;

namespace TennisCourt.Features.Users.Services;

public class UsersService(IUsersDataProvider usersDataProvider) : IUsersService
{
    public async Task<Guid> CreateAsync(UserDto user, CancellationToken cancellationToken = default)
    {

        if (user.Email == string.Empty)
            throw new ArgumentNullException(UserMessages.EmailIsEmpty, nameof(user.Email));
        if (user.Telephone == string.Empty)
            throw new ArgumentNullException(UserMessages.TelephoneIsEmpty, nameof(user.Telephone));
        if (user.Name == string.Empty)
            throw new ArgumentNullException(UserMessages.NameIsEmpty, nameof(user.Name));


        var userId = await usersDataProvider.CreateAsync(new User()
        {
            Email = user.Email,
            Telephone = user.Telephone,
            Name = user.Name
        }, cancellationToken);

        await usersDataProvider.SaveChangesAsync(cancellationToken);

        return userId;
    }

    public async Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {

        if (id == Guid.Empty)
            throw new ArgumentException(CommonMessages.IdIsEmpty);

        var user = await usersDataProvider.GetByIdAsync(id, cancellationToken);
        return new UserDto()
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Telephone = user.Telephone,
            Role = user.Role
        };

    }
}