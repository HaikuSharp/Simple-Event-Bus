using SEB.Abstraction;

namespace SEB.Hearing;

public class EventHearing<TEvent> : IEventHearing<TEvent> where TEvent : IEvent
{
    public static EventHearing<TEvent> Default => field ??= new();

    public virtual bool Hear(TEvent reason) => true;

    bool IEventHearing.Hear(IEvent reason) => reason is TEvent tevent && Hear(tevent);
}
