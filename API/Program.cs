using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // "using" conducts garbage collection when scope is no longer in use
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MeekinFirewatchContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            // log to terminal any errors we get
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            try
            {
                await context.Database.MigrateAsync();
                await DbInitializer.Initialize(context, userManager);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Problem migrating data.");
            }
            
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
