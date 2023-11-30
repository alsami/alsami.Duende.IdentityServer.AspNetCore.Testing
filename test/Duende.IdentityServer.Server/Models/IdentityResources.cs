using Duende.IdentityServer.Models;

namespace Duende.IdentityServer.Server.Models;

public static class ApiIdentityResources
{
    public static IEnumerable<IdentityResource> GetIdentityResources
        => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
}