using System.ComponentModel.DataAnnotations.Schema;

namespace TennisCourt.Infrastructure.Entities;

public class Booking
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CourtId { get; set; }
    public string Status { get; set; }
    public decimal Price { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }

}