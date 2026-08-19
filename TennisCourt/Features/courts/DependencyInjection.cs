using TennisCourt.Features.Courts.Data;
using TennisCourt.Features.Courts.Services;

namespace TennisCourt.Features.Courts;

public static class DependencyInjection
{
    public static IServiceCollection AddCourtsFeature(this IServiceCollection services)
    {
        services.AddScoped<ICourtsDataProvider,CourtsDataProvider>();
        services.AddScoped<ICourtsService,CourtsService>();

        return services;
    }
}