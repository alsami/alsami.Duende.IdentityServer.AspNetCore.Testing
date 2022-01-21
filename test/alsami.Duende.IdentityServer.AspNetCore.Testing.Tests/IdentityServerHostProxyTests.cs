using Autofac.Extensions.DependencyInjection;
using alsami.Duende.IdentityServer.AspNetCore.Testing.Builder;
using alsami.Duende.IdentityServer.AspNetCore.Testing.Configuration;
using alsami.Duende.IdentityServer.AspNetCore.Testing.Services;
using alsami.Duende.IdentityServer.AspNetCore.Testing.Tests.Shared;
using Duende.IdentityServer.Api;
using Duende.IdentityServer.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace alsami.Duende.IdentityServer.AspNetCore.Testing.Tests
{
    public class IdentityServerHostProxyTests
    {
        [Fact]
        public async Task GetDiscoverResponseAsync_ValidConfiguration_Succeeds()
        {
            var clientConfiguration = new ClientConfiguration("MyClient", "MySecret");

            var client = new Client
            {
                ClientId = clientConfiguration.Id,
                ClientSecrets = new List<Secret>
                {
                    new(clientConfiguration.Secret.Sha256())
                },
                AllowedScopes = new[] {"api1"},
                AllowedGrantTypes = new[] {GrantType.ClientCredentials},
                AccessTokenType = AccessTokenType.Jwt,
                AccessTokenLifetime = 7200
            };

            var hostBuilder = new IdentityServerTestHostBuilder()
                .AddClients(client)
                .AddApiResources(new ApiResource("api1", "api1name"))
                .AddApiScopes(new ApiScope("api1"))
                .CreateHostBuilder(new AutofacServiceProviderFactory(), ContainerBuilderConfiguration.ConfigureContainer);

            var identityServerProxy = new IdentityServerHostProxy(hostBuilder);

            var response = await identityServerProxy.GetDiscoverResponseAsync();

            Assert.NotNull(response);
        }
        
        [Fact]
        public async Task IdentityServerProxy_GetClientCredentialsAsync_Authorize_Api_Succeeds()
        {
            var clientConfiguration = new ClientConfiguration("MyClient", "MySecret");

            var client = new Client
            {
                ClientId = clientConfiguration.Id,
                ClientSecrets = new List<Secret>
                {
                    new(clientConfiguration.Secret.Sha256())
                },
                AllowedScopes = new[] {"api1"},
                AllowedGrantTypes = new[] {GrantType.ClientCredentials},
                AccessTokenType = AccessTokenType.Jwt,
                AccessTokenLifetime = 7200
            };

            var webHostBuilder = new IdentityServerTestHostBuilder()
                .AddClients(client)
                .AddApiResources(new ApiResource("api1", "api1name"))
                .AddApiScopes(new ApiScope("api1"))
                .CreateHostBuilder();

            var identityServerProxy = new IdentityServerHostProxy(webHostBuilder);

            var tokenResponse = await identityServerProxy.GetClientAccessTokenAsync(clientConfiguration, "api1");

            var apiWebHostBuilder = WebHost.CreateDefaultBuilder()
                .ConfigureServices(services =>
                    services.AddSingleton(identityServerProxy.IdentityServer.CreateHandler()))
                .UseStartup<Startup>();

            var apiServer = new TestServer(apiWebHostBuilder);

            var apiClient = apiServer.CreateClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var apiResponse = await apiClient.GetAsync("api/auth");

            Assert.True(apiResponse.IsSuccessStatusCode, "should have been authenticated!");
        }
    }
}