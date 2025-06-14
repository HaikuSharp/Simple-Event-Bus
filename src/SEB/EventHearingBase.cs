using SEB.Abstraction;

namespace SEB;

public abstract class EventHearingBase<TEvent> : IEventHearing where TEvent : IEvent
{
    public abstract bool Hear(TEvent reason);

    bool IEventHearing.Hear(IEvent reason) => reason is TEvent tevent && Hear(tevent);
}
