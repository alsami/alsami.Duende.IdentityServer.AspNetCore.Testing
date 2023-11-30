using Microsoft.Extensions.Logging;

namespace alsami.Duende.IdentityServer.AspNetCore.Testing.Tests.Validators;

public class ResourceOwnerValidatorWithDependencies : SimpleResourceOwnerPasswordValidator
{
    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
#pragma warning disable S4487
#pragma warning disable CS0169 // Field is never used
    private readonly ILogger<ResourceOwnerValidatorWithDependencies> logger;
#pragma warning restore CS0169 // Field is never used
#pragma warning restore S4487

    public ResourceOwnerValidatorWithDependencies(ILogger<ResourceOwnerValidatorWithDependencies> logger)
    {
        this.logger = logger;
    }
}