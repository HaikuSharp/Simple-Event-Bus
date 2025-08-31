namespace SEB.Abstraction;

/// <summary>
/// Represents an event dispatcher that can dispatch events of a specific type.
/// </summary>
/// <typeparam name="TLowLevelEvent">The base type of events that can be dispatched.</typeparam>
public interface IEventDispatcher<in TLowLevelEvent> where TLowLevelEvent : IEvent
{
    /// <summary>
    /// Dispatches an event to all subscribed listeners.
    /// </summary>
    /// <typeparam name="TEvent">The specific type of event to dispatch.</typeparam>
    /// <param name="reason">The event instance to dispatch.</param>
    void Dispatch<TEvent>(TEvent reason) where TEvent : TLowLevelEvent;
}