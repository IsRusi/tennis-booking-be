using TennisCourt.Features.Users.Data;
using TennisCourt.Features.Users.Services;

namespace TennisCourt.Features.Users;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersFeature(this IServiceCollection services)
    {
        services.AddScoped<IUsersDataProvider, UsersDataProvider>();
        services.AddScoped<IUsersService, UsersService>();
        return services;
    }
}