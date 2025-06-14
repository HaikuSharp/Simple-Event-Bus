using SEB.Abstraction;

namespace SEB;

public class EventHearing<TEvent> : IEventHearing where TEvent : IEvent
{
    public bool Hear(IEvent reason) => reason is TEvent;
}