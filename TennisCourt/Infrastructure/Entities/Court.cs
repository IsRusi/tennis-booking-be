namespace TennisCourt.Infrastructure.Entities;

public class Court
{
    public Guid Id { get; set; }
    public string Street { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string SurfaceType { get; set; } = String.Empty;
    public bool IsIndoor { get; set; }
}