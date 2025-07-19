using SEB.Abstraction;
using System;
using System.Collections.Generic;

namespace SEB;

/// <summary>
/// A default implementation of <see cref="IEventBus"/> that manages event listeners
/// and handles event distribution with priority ordering.
/// </summary>
public class EventBus : IEventBus
{
    private readonly List<IEventListener> m_Listeners = [];

    /// <summary>
    /// Subscribes a listener to receive events from this bus.
    /// </summary>
    /// <param name="listener">The listener to add.</param>
    /// <returns>
    /// An <see cref="IDisposable"/> that will unsubscribe the listener when disposed.
    /// </returns>
    public IDisposable Subscribe(IEventListener listener)
    {
        InternalAdd(listener);
        return CreateDisposable(listener);
    }

    /// <summary>
    /// Unsubscribes a listener from this bus.
    /// </summary>
    /// <param name="listener">The listener to remove.</param>
    public void Unsubscribe(IEventListener listener) => InternalRemove(listener);

    /// <summary>
    /// Emits an event to all subscribed listeners in priority order.
    /// </summary>
    /// <param name="reason">The event to distribute.</param>
    public void Emit(IEvent reason)
    {
        foreach(IEventListener listener in m_Listeners)
        {
            if(!listener.Hear(reason)) continue;
            listener.Emit(reason);
        }
    }

    /// <summary>
    /// Adds a listener to the collection if not already present, then sorts the collection.
    /// </summary>
    /// <param name="listener">The listener to add.</param>
    private void InternalAdd(IEventListener listener)
    {
        List<IEventListener> listeners = m_Listeners;
        if(listeners.Contains(listener)) return;
        listeners.Add(listener);
        listeners.Sort();
    }

    /// <summary>
    /// Removes a listener from the collection if present, then sorts the collection.
    /// </summary>
    /// <param name="listener">The listener to remove.</param>
    private void InternalRemove(IEventListener listener)
    {
        List<IEventListener> listeners = m_Listeners;
        if(!listeners.Remove(listener)) return;
        listeners.Sort();
    }

    private EventListenerDisposable CreateDisposable(IEventListener listener) => new(this, listener);

    private class EventListenerDisposable(IEventBus bus, IEventListener listener) : IDisposable
    {
        private readonly WeakReference<IEventBus> m_Bus = new(bus);
        private readonly WeakReference<IEventListener> m_Listener = new(listener);

        public void Dispose()
        {
            if(!m_Bus.TryGetTarget(out IEventBus bus)) return;
            if(!m_Listener.TryGetTarget(out IEventListener listener)) return;
            bus.Unsubscribe(listener);
        }
    }
}