using Microsoft.Extensions.Logging;

namespace Duende.IdentityServer.Contrib.AspNetCore.Testing.Tests.Validators
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