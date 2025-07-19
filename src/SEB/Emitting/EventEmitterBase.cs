using SEB.Abstraction;
using SEB.Exceptions;

namespace SEB.Emitting;

/// <summary>
/// Abstract base class for strongly-typed event emitters that provides type validation.
/// </summary>
/// <typeparam name="TEvent">The specific type of event this emitter can emit, must implement <see cref="IEvent"/>.</typeparam>
public abstract class EventEmitterBase<TEvent> : IEventEmitter<TEvent> where TEvent : IEvent
{
    /// <summary>
    /// When implemented in derived classes, emits the specified strongly-typed event.
    /// </summary>
    /// <param name="reason">The event instance to emit.</param>
    public abstract void Emit(TEvent reason);

    /// <summary>
    /// Emits an event after validating it matches the expected type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <param name="reason">The event to emit.</param>
    /// <exception cref="InvalidEventTypeException">
    /// Thrown when the provided event is not of type <typeparamref name="TEvent"/>.
    /// </exception>
    void IEventEmitter.Emit(IEvent reason) => Emit(InvalidEventTypeException.ThrowIfIsNot<TEvent>(reason));
}