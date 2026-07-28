using Microsoft.EntityFrameworkCore;
using TennisCourt.Infrastructure.Entities;

namespace TennisCourt.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Court> Courts { get; set; }
    public DbSet<Scheduler> Schedulers { get; set; }
    public DbSet<SlotDuration> SlotDurations { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Booking>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("now()");
    }
}