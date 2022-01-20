using System.Reflection;
using Microsoft.AspNetCore;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Duende.IdentityServer.Server
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            using var host = CreateWebHostBuilder(args).Build();

            return host.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] _)
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseSerilog(ConfigureLogger);
        }

        private static void ConfigureLogger(WebHostBuilderContext hostContext, LoggerConfiguration loggerConfiguration)
        {
            loggerConfiguration.Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile(Path.Combine(AppContext.BaseDirectory, "Logs",
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.log"))
                .WriteTo.Console(
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}",
                    theme: AnsiConsoleTheme.Literate);
        }
    }
}