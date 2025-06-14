using SEB.Abstraction;

namespace SEB;

public abstract class EventEmitterBase<TEvent> : IEventEmitter<TEvent> where TEvent : IEvent
{
    public abstract void Emit(TEvent reason);

    void IEventEmitter.Emit(IEvent reason)
    {
        if(reason is not TEvent tevent) return;
        Emit(tevent);
    }
}
