using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SecurityAPI.BLL;
using SecurityAPI.BLL.Interfaces;
using SecurityAPI.DAL.Interfaces;

namespace SecurityAPI.WEB
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            await CreateDbIfNotExists(host);
            
            await host.RunAsync();
        }
        
        private static async Task CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<Program>>();

                try
                {
                    var roleRepository = services.GetRequiredService<IRoleRepository>();
                    var userService = services.GetRequiredService<IUserService>();
                    await DataSeed.SeedSampleDataAsync(roleRepository, userService);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                    throw;
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
