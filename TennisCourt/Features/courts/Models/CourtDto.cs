namespace TennisCourt.Features.Courts.Models;

public class CourtDto
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string Name { get; set; }
    public string SurfaceType { get; set; }
    public bool IsIndoor { get; set; }
}