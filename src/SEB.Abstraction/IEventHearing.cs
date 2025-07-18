namespace SEB.Abstraction;

public interface IEventHearing
{
    bool Hear(IEvent reason);
}

public interface IEventHearing<in TEvent> : IEventHearing where TEvent : IEvent
{
    bool Hear(TEvent reason);
}
