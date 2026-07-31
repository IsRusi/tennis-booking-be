using TennisCourt.Infrastructure.Entities;

namespace TennisCourt.Features.Users.Data;

public interface IUsersDataProvider
{
    public Task<Guid> CreateAsync(User user, CancellationToken cancellationToken = default);
    public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task SaveChangesAsync(CancellationToken cancellationToken=default);
}