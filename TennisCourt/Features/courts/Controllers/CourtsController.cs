using Microsoft.AspNetCore.Mvc;
using TennisCourt.Features.Courts.Models;
using TennisCourt.Features.Courts.Services;

namespace TennisCourt.Features.Courts.Controllers;

[ApiController]
[Route("[controller]")]
public class CourtsController(ICourtsService courtsService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCourtRequest model, CancellationToken cancellationToken = default)
    {
        try
        {
            var createdId = await courtsService.CreateAsync(new CreateCourtDto()
            {
                Street = model.Street,
                Name = model.Name,
                SurfaceType = model.SurfaceType,
                IsIndoor = model.IsIndoor
            }, cancellationToken);

            return Ok(createdId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var courts = await courtsService.GetAllAsync(cancellationToken);

            return Ok(courts);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var court = await courtsService.GetByIdAsync(id, cancellationToken);

            return Ok(court);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}