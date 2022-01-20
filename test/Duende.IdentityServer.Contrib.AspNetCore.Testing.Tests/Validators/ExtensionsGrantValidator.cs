using System.Security.Claims;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using IdentityModel;

namespace Duende.IdentityServer.Contrib.AspNetCore.Testing.Tests.Validators
{
    public class ExtensionsGrantValidator : IExtensionGrantValidator
    {
        public Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            if (context.Request.Raw["username"] != "user" || context.Request.Raw["password"] != "password")
            {
                context.Result =
                    new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Username or password is wrong!");
                return Task.CompletedTask;
            }

            context.Result = new GrantValidationResult("user", "custom", new List<Claim>
            {
                new(JwtClaimTypes.Subject, "user")
            });

            return Task.CompletedTask;
        }

        public string GrantType => "Custom";
    }
}