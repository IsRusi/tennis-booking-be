using TennisCourt.Features.Courts.Data;
using TennisCourt.Features.Courts.Models;
using TennisCourt.Infrastructure.Constants;
using TennisCourt.Infrastructure.Entities;

namespace TennisCourt.Features.Courts.Services;

public class CourtsService(ICourtsDataProvider courtsDataProvider) : ICourtsService
{
    public async Task<Guid> CreateAsync(CreateCourtDto court, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(court.Street))
            throw new ArgumentNullException(nameof(court.Street), CourtMessages.IsEmpty<string>(court.Street));
        if (string.IsNullOrEmpty(court.Name))
            throw new ArgumentNullException(nameof(court.Name), CourtMessages.IsEmpty<string>(court.Name));
        if (string.IsNullOrEmpty(court.SurfaceType))
            throw new ArgumentNullException(nameof(court.SurfaceType), CourtMessages.IsEmpty<string>(court.SurfaceType));


        var recievedId = await courtsDataProvider.CreateAsync(new Court()
        {
            Street = court.Street,
            Name = court.Name,
            SurfaceType = court.SurfaceType,
            IsIndoor = court.IsIndoor
        }, cancellationToken);

        await courtsDataProvider.SaveChangesAsync(cancellationToken);
        return recievedId;
    }

    public async Task<IEnumerable<CourtDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var courts = await courtsDataProvider.GetAllAsync(cancellationToken);

        var courtsDto = courts.Select(court => new CourtDto()
        {
            Id = court.Id,
            Street = court.Street,
            Name = court.Name,
            SurfaceType = court.SurfaceType,
            IsIndoor = court.IsIndoor
        });

        return courtsDto;
    }

    public async Task<CourtDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id), CourtMessages.IdIsEmpty);

        var court = await courtsDataProvider.GetByIdAsync(id, cancellationToken);

        if (court is null)
            throw new ArgumentNullException(nameof(court), CourtMessages.IsNull);

        return new CourtDto()
        {
            Id = court.Id,
            Street = court.Street,
            Name = court.Name,
            SurfaceType = court.SurfaceType,
            IsIndoor = court.IsIndoor
        };
    }
}