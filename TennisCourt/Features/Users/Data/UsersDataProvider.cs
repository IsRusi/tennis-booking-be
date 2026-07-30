using Microsoft.EntityFrameworkCore;
using TennisCourt.Infrastructure.Constants;
using TennisCourt.Infrastructure.Data;
using TennisCourt.Infrastructure.Entities;

namespace TennisCourt.Features.Users.Data;

public class UsersDataProvider(AppDbContext context) : IUsersDataProvider
{
    private const string ROLE_CLIENT = "Client";
    public async Task<Guid> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        if (user is null)
            throw new ArgumentNullException(UserMessages.IsNull, nameof(user));

        user.Role = ROLE_CLIENT;

        await context.Users.AddAsync(user, cancellationToken);
        return user.Id;
    }

    public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}