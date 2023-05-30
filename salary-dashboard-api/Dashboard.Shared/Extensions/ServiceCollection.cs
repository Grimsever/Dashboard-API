using Dashboard.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Shared.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddHostedService<AppInitializer>();

            return services;
        }
    }
}
