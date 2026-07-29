using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TennisCourt.Infrastructure.Entities;

public class Court
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Street { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string SurfaceType { get; set; } = String.Empty;
    public bool IsIndoor { get; set; }
}