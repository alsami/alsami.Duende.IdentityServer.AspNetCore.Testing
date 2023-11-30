using Autofac;

namespace alsami.Duende.IdentityServer.AspNetCore.Testing.Tests.Shared;

public static class ContainerBuilderConfiguration
{
    public static void ConfigureContainer(ContainerBuilder containerBuilder) =>
        containerBuilder.RegisterType<Dependency>().AsSelf();
}