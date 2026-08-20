using TennisCourt.Infrastructure.Entities;

namespace TennisCourt.Features.Schedulers.Data;

public interface ISchedulersDataProvider
{
    public Task<Guid> CreateAsync(Scheduler scheduler, CancellationToken cancellationToken = default);
    public Task<Scheduler> GetByCourtIdAsync(Guid courtId, CancellationToken cancellationToken = default);
    public Task<Scheduler> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);

}