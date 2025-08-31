using System;

namespace SEB.Abstraction;

/// <summary>
/// Represents an event listener that can handle events of a specific type.
/// </summary>
/// <typeparam name="TLowLevelEvent">The base type of events that can be handled.</typeparam>
public interface IEventListener<in TLowLevelEvent> : IEventListener, IComparable<IEventListener> where TLowLevelEvent : IEvent
{
    /// <summary>
    /// Handles a specific event.
    /// </summary>
    /// <typeparam name="TEvent">The specific type of event to handle.</typeparam>
    /// <param name="reason">The event instance to handle.</param>
    void Listen<TEvent>(TEvent reason) where TEvent : TLowLevelEvent;
}

/// <summary>
/// Represents a base event listener with ordering capability.
/// </summary>
public interface IEventListener : IComparable<IEventListener>
{
    /// <summary>
    /// Gets the order in which this listener should be executed relative to other listeners.
    /// </summary>
    int Order { get; }
}