using alsami.Duende.IdentityServer.AspNetCore.Testing.Misc;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Services;

namespace alsami.Duende.IdentityServer.AspNetCore.Testing.Sinks;

internal class EventCaptureSink : IEventSink
{
    private readonly IdentityServerEventCaptureStore identityServerEventCaptureStore;

    public EventCaptureSink(IdentityServerEventCaptureStore identityServerEventCaptureStore)
    {
        this.identityServerEventCaptureStore = identityServerEventCaptureStore;
    }

    public Task PersistAsync(Event evt)
    {
        this.identityServerEventCaptureStore.AddEvent(evt);
        return Task.CompletedTask;
    }
}