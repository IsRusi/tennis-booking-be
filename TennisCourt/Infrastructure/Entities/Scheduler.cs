namespace TennisCourt.Infrastructure.Entities;

public class Scheduler
{
    public Guid Id { get; set; }
    public Guid CourtId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public Guid SlotDurationId { get; set; }
}