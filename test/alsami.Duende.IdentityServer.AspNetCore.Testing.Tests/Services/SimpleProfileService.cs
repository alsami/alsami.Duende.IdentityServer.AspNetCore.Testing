using System.Security.Claims;
using Duende.IdentityModel;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;

namespace alsami.Duende.IdentityServer.AspNetCore.Testing.Tests.Services;

public class SimpleProfileService : IProfileService

{
    public Task GetProfileDataAsync(ProfileDataRequestContext context, CancellationToken ct)
    {
        var subject = context.Subject.Claims.First(claim => claim.Type == JwtClaimTypes.Subject).Value;

        context.IssuedClaims = [new Claim(JwtClaimTypes.Subject, subject)];

        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context, CancellationToken ct)
    {
        context.IsActive = true;
        return Task.CompletedTask;
    }
}