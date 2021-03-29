using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SecuredSqlSample.Web
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var rootCommand = new RootCommand{
                new Option<bool>("--migrate", "Whether to run database migrations"),
                new Option<bool>("--thenExit", "Whether to exit after migrations (instead of starting web app)")
            };

            rootCommand.Handler = CommandHandler.Create<bool, bool>(async (migrate, thenExit) =>
            {
                if (migrate)
                {
                    using (var scope = host.Services.CreateScope())
                    {
                        var services = scope.ServiceProvider;
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogInformation("Running migrations");
                        var profileDbContext = services
                            .GetService<ProfileDbContext>();
                        await profileDbContext.Database.MigrateAsync();
                    }
                }
                if (!thenExit)
                {
                    await host.RunAsync();
                }
            });
            return await rootCommand.InvokeAsync(args);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
