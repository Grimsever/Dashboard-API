using System.Reflection;
using Dashboard.Abstraction.Commands;
using Dashboard.Abstraction.Queries;
using Dashboard.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Abstraction.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
