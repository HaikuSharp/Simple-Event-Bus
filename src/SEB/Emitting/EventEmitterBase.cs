using SEB.Abstraction;
using SEB.Exceptions;

namespace SEB.Emitting;

public abstract class EventEmitterBase<TEvent> : IEventEmitter<TEvent> where TEvent : IEvent
{
    public abstract void Emit(TEvent reason);

    void IEventEmitter.Emit(IEvent reason) => Emit(InvalidEventTypeException.ThrowIfIsNot<TEvent>(reason));
}
