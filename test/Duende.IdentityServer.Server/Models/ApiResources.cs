using Duende.IdentityServer.Models;

namespace Duende.IdentityServer.Server.Models
{
    public static class ApiResources
    {
        public static IEnumerable<ApiResource> GetApiResources
            => new List<ApiResource>
            {
                new("api1", "api1")
            };
    }
}