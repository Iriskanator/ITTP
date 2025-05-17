using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ITTP
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var path = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!;

                    webBuilder
                        .ConfigureAppConfiguration((ctx, configHost) =>
                        {
                            var env = ctx.HostingEnvironment;

                            configHost
                                .AddJsonFile(Path.Combine(path, "appsettings.yaml"), optional: true, reloadOnChange: true)
                                .AddJsonFile(Path.Combine(path, $"appsettings.{env.EnvironmentName}.yaml"), optional: true, reloadOnChange: true)
                                .AddEnvironmentVariables();
                        })
                        .UseStartup<Startup>();
                });
    }
}