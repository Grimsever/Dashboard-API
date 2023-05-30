using Dashboard.Application.Services;
using Dashboard.Domain.Repositories;
using Dashboard.Infrastructure.EF.Contexts;
using Dashboard.Infrastructure.EF.Options;
using Dashboard.Infrastructure.EF.Repositories;
using Dashboard.Infrastructure.EF.Services;
using Dashboard.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Infrastructure.EF.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, PostgresUserRepository>();
            services.AddScoped<IIncomeListRepository, PostgresIncomeListRepository>();
            services.AddScoped<IIncomeListReadService, PostgresIncomeListReadService>();

            var options = configuration.GetOptions<PostgresOptions>("ConnectionStrings");

            services.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(options.DashboardDb));
            services.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(options.DashboardDb));
            return services;
        }
    }
}
