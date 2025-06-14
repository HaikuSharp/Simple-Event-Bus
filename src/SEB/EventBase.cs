using SEB.Abstraction;

namespace SEB;

public abstract class EventBase : IEvent
{
    public virtual string Name => GetType().FullName;
}
