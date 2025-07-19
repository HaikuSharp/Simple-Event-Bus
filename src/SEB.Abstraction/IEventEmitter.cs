namespace SEB.Abstraction;

/// <summary>
/// Represents an object that can emit events of any type.
/// </summary>
public interface IEventEmitter
{
    /// <summary>
    /// Emits an event to be processed by listeners.
    /// </summary>
    /// <param name="reason">The event to emit.</param>
    void Emit(IEvent reason);
}

/// <summary>
/// Represents an object that can emit strongly-typed events.
/// </summary>
/// <typeparam name="TEvent">The type of event this emitter can produce, must implement <see cref="IEvent"/>.</typeparam>
public interface IEventEmitter<in TEvent> : IEventEmitter where TEvent : IEvent
{
    /// <summary>
    /// Emits a strongly-typed event to be processed by listeners.
    /// </summary>
    /// <param name="reason">The typed event to emit.</param>
    void Emit(TEvent reason);
}