using Duende.IdentityServer.Test;

namespace Duende.IdentityServer.Server.Models
{
    public static class TestUsers
    {
        public static List<TestUser> GeTestUsers()
        {
            return new List<TestUser>
            {
                new()
                {
                    Username = "user1",
                    Password = "password1",
                    IsActive = true,
                    SubjectId = "user1"
                }
            };
        }
    }
}