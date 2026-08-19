using TennisCourt.Features.Courts.Models;

namespace TennisCourt.Features.Courts.Services;

public interface ICourtsService
{
    public Task<Guid> CreateAsync(CreateCourtDto court, CancellationToken cancellationToken = default);
    public Task<IEnumerable<CourtDto>> GetAllAsync(CancellationToken cancellationToken = default);
    public Task<CourtDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
