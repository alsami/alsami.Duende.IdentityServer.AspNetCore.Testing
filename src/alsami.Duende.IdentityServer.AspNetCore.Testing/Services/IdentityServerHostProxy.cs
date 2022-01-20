using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace alsami.Duende.IdentityServer.AspNetCore.Testing.Services;

public sealed class IdentityServerHostProxy : AbstractIdentityServerProxy, IAsyncDisposable
{
    private readonly IHost host;

    public IdentityServerHostProxy(IHostBuilder hostBuilder)
    {
        if (hostBuilder is null) throw new ArgumentNullException(nameof(hostBuilder));

        this.host = hostBuilder.Start();
    }

    public override TestServer IdentityServer => this.host.GetTestServer();

    public async ValueTask DisposeAsync()
    {
        if (this.host is null) return;

        await this.host.StopAsync();
    }
}