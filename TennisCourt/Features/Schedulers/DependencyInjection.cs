
using TennisCourt.Features.Schedulers.Data;

namespace TennisCourt.Features.Schedulers;

public static class DependencyInjection
{
    public static IServiceCollection AddSchedulersFeature(this IServiceCollection services)
    {
        services.AddScoped<ISchedulersDataProvider, SchedulersDataProvider>();

        return services;
    }
}