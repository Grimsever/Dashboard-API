using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SecurityAPI.BLL.Implementations;
using SecurityAPI.BLL.Interfaces;

namespace SecurityAPI.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}