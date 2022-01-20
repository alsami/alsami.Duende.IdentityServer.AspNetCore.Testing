using Autofac;

namespace Duende.IdentityServer.Contrib.AspNetCore.Testing.Tests.Shared
{
    public static class ContainerBuilderConfiguration
    {
        public static void ConfigureContainer(ContainerBuilder containerBuilder) =>
            containerBuilder.RegisterType<Dependency>().AsSelf();
    }
}