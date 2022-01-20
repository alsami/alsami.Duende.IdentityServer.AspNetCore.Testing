using Duende.IdentityServer.Models;

namespace Duende.IdentityServer.Server.Models
{
    public static class Clients
    {
        public const string Id = "sampleclient";
        public const string Secret = "samplesecret";

        public static IEnumerable<Client> GetClients
            => new List<Client>
            {
                new()
                {
                    ClientId = Id,
                    ClientSecrets = new List<Secret>
                    {
                        new(Secret.Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "api1", IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    AllowedGrantTypes = new List<string>
                    {
                        GrantType.ResourceOwnerPassword
                    },
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 60 * 60,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Absolute
                }
            };
    }
}