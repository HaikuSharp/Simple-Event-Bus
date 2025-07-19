using System;

namespace SEB.Abstraction;

/// <summary>
/// Represents an event bus that manages event subscriptions and distribution.
/// </summary>
public interface IEventBus : IEventEmitter
{
    /// <summary>
    /// Subscribes an event listener to receive events from this bus.
    /// </summary>
    /// <param name="listener">The listener to subscribe.</param>
    /// <returns>
    /// An <see cref="IDisposable"/> that can be used to unsubscribe the listener
    /// by disposing it.
    /// </returns>
    IDisposable Subscribe(IEventListener listener);

    /// <summary>
    /// Unsubscribes an event listener from this bus.
    /// </summary>
    /// <param name="listener">The listener to unsubscribe.</param>
    void Unsubscribe(IEventListener listener);
}