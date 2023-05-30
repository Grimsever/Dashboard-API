using Dashboard.Abstraction.Extensions;
using Dashboard.Infrastructure.EF.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddPostgres(configuration);
            services.AddQueries();

            return services;
        }
    }
}
