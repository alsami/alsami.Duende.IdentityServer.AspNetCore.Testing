
namespace Duende.IdentityServer.Server;

public static class Program
{
    public static async Task Main(string[] args)
    {
        using var host = CreateWebHostBuilder(args).Build();
        await host.RunAsync();
    }

    private static IHostBuilder CreateWebHostBuilder(string[] args)
    {
        return Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHost(webHost => webHost.UseStartup<Startup>());
    }
}