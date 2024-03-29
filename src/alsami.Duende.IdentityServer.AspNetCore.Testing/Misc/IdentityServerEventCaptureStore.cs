using Duende.IdentityServer.Events;

namespace alsami.Duende.IdentityServer.AspNetCore.Testing.Misc;

internal class IdentityServerEventCaptureStore
{
    private readonly List<Event> events;

    public IdentityServerEventCaptureStore()
    {
        this.events = new List<Event>();
    }

    public void AddEvent(Event @event)
    {
        if (@event == null) throw new ArgumentNullException(nameof(@event));

        this.events.Add(@event);
    }

    public Event? GetById(int id)
    {
        return this.events.Find(e => e.Id == id);
    }

    public IEnumerable<Event> GetEvents()
    {
        return this.events.AsReadOnly();
    }

    public bool ContainsEventType(EventTypes eventType)
    {
        var @event = this.events.Find(e => e.EventType == eventType);
        return @event != null;
    }

    public bool ContainsMessage(string message, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
    {
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

        var matchingEvents = this.events.Where(e => string.Compare(e.Message, message, comparison) == 0);
        return matchingEvents.Any();
    }

    public bool ContainsMessageStartsWith(string value,
        StringComparison comparison = StringComparison.OrdinalIgnoreCase)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));

        var matchingEvents = this.events.Where(e => e.Message is not null && e.Message.StartsWith(value, comparison));
        return matchingEvents.Any();
    }
}