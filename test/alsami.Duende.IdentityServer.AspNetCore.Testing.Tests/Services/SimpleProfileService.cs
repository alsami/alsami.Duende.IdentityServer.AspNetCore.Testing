using System.Security.Claims;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;

namespace alsami.Duende.IdentityServer.AspNetCore.Testing.Tests.Services;

public class SimpleProfileService : IProfileService

{
    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var subject = context.Subject.Claims.First(claim => claim.Type == JwtClaimTypes.Subject).Value;

        context.IssuedClaims = new List<Claim>
        {
            new(JwtClaimTypes.Subject, subject)
        };

        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive = true;
        return Task.CompletedTask;
    }
}