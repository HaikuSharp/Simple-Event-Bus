using SEB.Abstraction;

namespace SEB;

public class EventListener(IEventHearing hearing, IEventEmitter emitter, int order) : IEventListener
{
    public int Order => order;

    public bool Hear(IEvent reason) => hearing.Hear(reason);

    public void Emit(IEvent reason) => emitter.Emit(reason);

    public int CompareTo(IEventListener other) => Order.CompareTo(other.Order);
}
