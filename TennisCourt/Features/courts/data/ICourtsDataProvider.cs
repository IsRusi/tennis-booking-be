using System.Collections;
using TennisCourt.Infrastructure.Entities;

namespace TennisCourt.Features.Courts;

public interface ICourtsDataProvider
{
    public Task<Guid> CreateAsync(Court court, CancellationToken cancellationToken = default);
    public Task<IEnumerable<Court>> GetAllAsync(CancellationToken cancellationToken = default);
    public Task<Court> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}