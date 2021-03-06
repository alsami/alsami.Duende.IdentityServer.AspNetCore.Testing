using alsami.Duende.IdentityServer.AspNetCore.Testing.Misc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// ReSharper disable UnusedMember.Global

namespace alsami.Duende.IdentityServer.AspNetCore.Testing.Builder;

public sealed class IdentityServerTestHostBuilder : AbstractIdentityServerHostBuilder<IdentityServerTestHostBuilder>
{
    private Action<HostBuilderContext, ILoggingBuilder> internalLoggingBuilder;
    private Action<HostBuilderContext, IConfigurationBuilder> internalConfigurationBuilder;
    private Action<HostBuilderContext, IServiceCollection> internalServicesBuilder;

    public IdentityServerTestHostBuilder()
    {
        this.internalConfigurationBuilder = (context, configurationBuilder) => { };

        this.internalServicesBuilder = (builder, services) => { };

        this.internalLoggingBuilder = (context, loggingBuilder) =>
            loggingBuilder.AddProvider(new DefaultLoggerProvider());
    }

    public IdentityServerTestHostBuilder UseConfigurationBuilder(
        Action<HostBuilderContext, IConfigurationBuilder> configurationBuilder)
    {
        this.internalConfigurationBuilder = configurationBuilder;

        return this;
    }

    public IdentityServerTestHostBuilder UseServices(
        Action<HostBuilderContext, IServiceCollection> servicesBuilder)
    {
        this.internalServicesBuilder = servicesBuilder;

        return this;
    }

    public IdentityServerTestHostBuilder UseLoggingBuilder(
        Action<HostBuilderContext, ILoggingBuilder> loggingBuilder)
    {
        this.internalLoggingBuilder = loggingBuilder ??
                                      throw new ArgumentNullException(nameof(loggingBuilder),
                                          "loggingBuilder must not be null");

        return this;
    }

    public IHostBuilder CreateHostBuilder()
    {
        this.Validate();

        return this.CreateHostBuilderInternal();
    }

    public IHostBuilder CreateHostBuilder<TContainer>(
        IServiceProviderFactory<TContainer> serviceProviderFactory, Action<TContainer> containerSetupAction) where TContainer : notnull
    {
        if (serviceProviderFactory is null) throw new ArgumentNullException(nameof(serviceProviderFactory));
        if (containerSetupAction is null) throw new ArgumentNullException(nameof(containerSetupAction));

        this.Validate();

        return this.CreateHostBuilderInternal()
            .UseServiceProviderFactory(serviceProviderFactory)
            .ConfigureContainer(containerSetupAction);
    }

    private IHostBuilder CreateHostBuilderInternal()
    {
        return new HostBuilder()
            .ConfigureLogging(this.internalLoggingBuilder)
            .ConfigureWebHost(webHostBuilder =>
            {
                webHostBuilder
                    .UseTestServer()
                    .Configure(applicationBuilder =>
                    {
                        applicationBuilder.UseIdentityServer();
                        this.InternalApplicationBuilder(applicationBuilder);
                    });
            })
            .ConfigureServices((context, services) =>
            {
                this.internalServicesBuilder(context, services);

                this.ConfigureIdentityServerServices(services);

                var identityServerBuilder = this.CreatePreconfiguredIdentityServerBuilder(services);

                this.ConfigureIdentityServerResources(identityServerBuilder);
            })
            .ConfigureAppConfiguration(this.internalConfigurationBuilder);
    }
}