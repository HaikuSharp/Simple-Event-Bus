namespace SEB.Abstraction;

/// <summary>
/// Represents an object that can receive and process events of any type.
/// </summary>
public interface IEventHearing
{
    /// <summary>
    /// Processes an incoming event.
    /// </summary>
    /// <param name="reason">The event to be processed.</param>
    /// <returns>
    /// <c>true</c> if the event was successfully processed;
    /// <c>false</c> if the event was not handled.
    /// </returns>
    bool Hear(IEvent reason);
}

/// <summary>
/// Represents an object that can receive and process events of a specific type.
/// </summary>
/// <typeparam name="TEvent">The type of event this handler can process, must implement <see cref="IEvent"/>.</typeparam>
public interface IEventHearing<in TEvent> : IEventHearing where TEvent : IEvent
{
    /// <summary>
    /// Processes an incoming strongly-typed event.
    /// </summary>
    /// <param name="reason">The event to be processed.</param>
    /// <returns>
    /// <c>true</c> if the event was successfully processed;
    /// <c>false</c> if the event was not handled.
    /// </returns>
    bool Hear(TEvent reason);
}