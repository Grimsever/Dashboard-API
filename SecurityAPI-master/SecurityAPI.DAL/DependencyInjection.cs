using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecurityAPI.DAL.Implementations;
using SecurityAPI.DAL.Interfaces;
using SecurityAPI.DAL.Persistence;

namespace SecurityAPI.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var sqlConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SecurityAPIContext>(options =>
                options.UseNpgsql(
                    sqlConnectionString,
                    b => b.MigrationsAssembly(typeof(SecurityAPIContext).Assembly.FullName)));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}