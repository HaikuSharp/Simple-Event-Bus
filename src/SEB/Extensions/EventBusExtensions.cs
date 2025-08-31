using SEB.Abstraction;
using System;

namespace SEB.Extensions;

/// <summary>
/// Provides extension methods for event listener providers.
/// </summary>
public static class EventListenerProviderExtensions
{
    /// <summary>
    /// Subscribes a listener and returns a scope that will automatically unsubscribe when disposed.
    /// </summary>
    /// <param name="provider">The event listener provider.</param>
    /// <param name="listener">The listener to subscribe.</param>
    /// <returns>A disposable scope that will unsubscribe the listener when disposed.</returns>
    public static SubscribeScope SubscribeWithScope(this IEventListenerProvider provider, IEventListener listener)
    {
        provider.Subscribe(listener);
        return new(provider, listener);
    }

    /// <summary>
    /// Unsubscribes a listener and returns a scope that will automatically resubscribe when disposed.
    /// </summary>
    /// <param name="provider">The event listener provider.</param>
    /// <param name="listener">The listener to unsubscribe.</param>
    /// <returns>A disposable scope that will resubscribe the listener when disposed.</returns>
    public static UnsubscribeScope UnsubscribeWithScope(this IEventListenerProvider provider, IEventListener listener)
    {
        provider.Unsubscribe(listener);
        return new(provider, listener);
    }

    /// <summary>
    /// Represents a scope that automatically unsubscribes a listener when disposed.
    /// </summary>
    public readonly struct SubscribeScope(IEventListenerProvider provider, IEventListener listener) : IDisposable
    {
        /// <summary>
        /// Unsubscribes the listener.
        /// </summary>
        public void Dispose() => provider.Unsubscribe(listener);
    }

    /// <summary>
    /// Represents a scope that automatically resubscribes a listener when disposed.
    /// </summary>
    public readonly struct UnsubscribeScope(IEventListenerProvider provider, IEventListener listener) : IDisposable
    {
        /// <summary>
        /// Resubscribes the listener.
        /// </summary>
        public void Dispose() => provider.Subscribe(listener);
    }
}