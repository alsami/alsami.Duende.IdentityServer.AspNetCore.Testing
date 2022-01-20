using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Duende.IdentityServer.Contrib.AspNetCore.Testing.Misc;

internal class DefaultLoggerProvider : ILoggerProvider
{
    private readonly ILoggerFactory loggerFactory;

    public DefaultLoggerProvider(ILoggerFactory? loggerFactor = null)
    {
        this.loggerFactory = loggerFactor ?? new NullLoggerFactory();
    }

    public ILogger CreateLogger(string categoryName)
    {
        return this.loggerFactory.CreateLogger(categoryName);
    }

    public void Dispose()
    {
        this.loggerFactory.Dispose();
        GC.SuppressFinalize(this);
    }
}