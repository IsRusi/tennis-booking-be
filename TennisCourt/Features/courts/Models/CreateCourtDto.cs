namespace TennisCourt.Features.Courts.Models;

public class CreateCourtDto
{
    public string Street { get; set; }
    public string Name { get; set; }
    public string SurfaceType { get; set; }
    public bool IsIndoor { get; set; }
}