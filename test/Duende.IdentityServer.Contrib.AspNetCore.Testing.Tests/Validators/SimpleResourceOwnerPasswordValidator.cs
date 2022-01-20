using System.Security.Claims;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using IdentityModel;

namespace Duende.IdentityServer.Contrib.AspNetCore.Testing.Tests.Validators
{
    public class SimpleResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (context.UserName != "user" || context.Password != "password")
            {
                context.Result =
                    new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Username or password is wrong!");
                return Task.CompletedTask;
            }

            context.Result = new GrantValidationResult("user", OidcConstants.AuthenticationMethods.Password,
                new List<Claim>
                {
                    new(JwtClaimTypes.Subject, "user")
                });

            return Task.CompletedTask;
        }
    }
}