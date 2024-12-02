using System.Reflection;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Server.Models;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Duende.IdentityServer.Server;

public class Startup
{
#pragma warning disable S2325
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging().AddSerilog(ConfigureLogger);

        services.AddIdentityServer(options =>
            {
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseErrorEvents = true;
            })
            .AddDefaultEndpoints()
            .AddDefaultSecretParsers()
            .AddDeveloperSigningCredential()
            .AddInMemoryCaching()
            .AddTestUsers(TestUsers.GeTestUsers())
            .AddInMemoryClients(Clients.GetClients)
            .AddInMemoryApiResources(ApiResources.GetApiResources)
            .AddInMemoryApiScopes(new[]
            {
                new ApiScope("api1"),
            })
            .AddInMemoryIdentityResources(ApiIdentityResources.GetIdentityResources);
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseIdentityServer();

        app.Run(ctx =>
        {
            var logger = ctx.RequestServices.GetRequiredService<ILogger<Startup>>();
            logger.LogInformation("Logging!");
            return Task.CompletedTask;
        });
    }
    
#pragma warning restore S2325

    private static void ConfigureLogger(LoggerConfiguration loggerConfiguration)
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