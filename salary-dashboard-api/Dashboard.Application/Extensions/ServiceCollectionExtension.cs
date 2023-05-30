using Dashboard.Abstraction.Extensions;
using Dashboard.Domain.Factories;
using Dashboard.Domain.Policies;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();

            services.AddSingleton<IIncomeListFactory, IncomeListFactory>();

            services.Scan(b => b.FromAssemblies(typeof(IIncomePolicy).Assembly)
                .AddClasses(c => c.AssignableTo<IIncomePolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }
    }
}
