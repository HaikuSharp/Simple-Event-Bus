using SEB.Abstraction;

namespace SEB;

public class EventListener(int order, IEventHearing hearing, IEventEmitter emitter) : IEventListener
{
    public int Order => order;

    public bool Hear(IEvent reason) => hearing.Hear(reason);

    public void Emit(IEvent reason) => emitter.Emit(reason);

    public int CompareTo(IEventListener other) => Order.CompareTo(other.Order);
}
