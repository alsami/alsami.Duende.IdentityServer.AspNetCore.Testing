using Microsoft.AspNetCore;

namespace Duende.IdentityServer.Server;

public static class Program
{
    public static async Task Main(string[] args)
    {
        using var host = CreateWebHostBuilder(args).Build();
        await host.RunAsync();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] _)
    {
        return WebHost
            .CreateDefaultBuilder()
            .UseStartup<Startup>();
    }
}