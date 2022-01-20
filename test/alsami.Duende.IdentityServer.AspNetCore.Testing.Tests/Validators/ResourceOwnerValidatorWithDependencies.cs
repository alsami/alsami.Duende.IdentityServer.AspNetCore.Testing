using Microsoft.Extensions.Logging;

namespace alsami.Duende.IdentityServer.AspNetCore.Testing.Tests.Validators
{
    public class ResourceOwnerValidatorWithDependencies : SimpleResourceOwnerPasswordValidator
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly ILogger<ResourceOwnerValidatorWithDependencies> logger;

        public ResourceOwnerValidatorWithDependencies(ILogger<ResourceOwnerValidatorWithDependencies> logger)
        {
            this.logger = logger;
        }
    }
}