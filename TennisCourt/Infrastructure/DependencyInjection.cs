using Microsoft.EntityFrameworkCore;
using TennisCourt.Infrastructure.Data;

namespace TennisCourt.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
}