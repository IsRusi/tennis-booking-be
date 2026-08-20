using Microsoft.EntityFrameworkCore;
using TennisCourt.Infrastructure.Constants;
using TennisCourt.Infrastructure.Data;
using TennisCourt.Infrastructure.Entities;

namespace TennisCourt.Features.Schedulers.Data;

public class SchedulersDataProvider(AppDbContext context) : ISchedulersDataProvider
{
    public async Task<Guid> CreateAsync(Scheduler scheduler, CancellationToken cancellationToken = default)
    {
        if (scheduler is null)
            throw new ArgumentNullException(nameof(scheduler), SchedulerMessages.IsNull);

        await context.Schedulers.AddAsync(scheduler);

        return scheduler.Id;
    }

    public async Task<Scheduler> GetByCourtIdAsync(Guid courtId, CancellationToken cancellationToken = default)
    => await context.Schedulers.FirstOrDefaultAsync(scheduler => scheduler.CourtId == courtId, cancellationToken);

    public async Task<Scheduler> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await context.Schedulers.FirstOrDefaultAsync(scheduler => scheduler.Id == id, cancellationToken);

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}