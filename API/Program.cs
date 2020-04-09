using System;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerfactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                       var context = services.GetRequiredService<StoreContext>();
                       await context.Database.MigrateAsync(); 
                       await StoreContextSeed.SeedAsync(context, loggerfactory);
                }
                catch(Exception e)
                {
                    var logger = loggerfactory.CreateLogger<Program>();
                    logger.LogError(e, "Error occured during migration");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
