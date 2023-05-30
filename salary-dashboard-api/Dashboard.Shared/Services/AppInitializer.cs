using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dashboard.Shared.Services
{
    public class AppInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public AppInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellation)
        {
            var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(DbContext).IsAssignableFrom(x) && !x.IsInterface && x != typeof(DbContext));

            using var scope = _serviceProvider.CreateScope();

            foreach (var dbContextType in dbContextTypes)
            {
                var dbContext = scope.ServiceProvider.GetRequiredService(dbContextType) as DbContext;

                if (dbContext is null)
                {
                    continue;
                }

                await dbContext.Database.MigrateAsync(cancellation);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
