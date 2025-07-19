using System;

namespace SEB.Abstraction;

/// <summary>
/// Represents an event listener that can both emit and handle events,
/// with defined ordering relative to other listeners.
/// </summary>
public interface IEventListener : IEventEmitter, IEventHearing, IComparable<IEventListener>
{
    /// <summary>
    /// Gets the priority order of this listener relative to other listeners.
    /// </summary>
    /// <value>
    /// An integer value indicating the listener's priority, where lower values
    /// indicate higher priority in event processing order.
    /// </value>
    int Order { get; }
}