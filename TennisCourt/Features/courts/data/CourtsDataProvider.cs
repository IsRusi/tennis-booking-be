using Microsoft.EntityFrameworkCore;
using TennisCourt.Infrastructure.Constants;
using TennisCourt.Infrastructure.Data;
using TennisCourt.Infrastructure.Entities;

namespace TennisCourt.Features.Courts;

public class CourtsDataProvider(AppDbContext context) : ICourtsDataProvider
{
    public async Task<Guid> CreateAsync(Court court, CancellationToken cancellationToken = default)
    {

        if (court is null)
            throw new ArgumentNullException(nameof(court), CourtMessages.IsNull);

        await context.AddAsync(court, cancellationToken);

        return court.Id;
    }

    public async Task<IEnumerable<Court>> GetAllAsync(CancellationToken cancellationToken = default)
    => await context.Courts.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Court> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await context.Courts.FirstOrDefaultAsync(court => court.Id == id, cancellationToken);

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}