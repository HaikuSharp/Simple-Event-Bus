using SEB.Abstraction;
using System;
using System.Collections.Generic;

namespace SEB;

/// <summary>
/// Default implementation of an untyped event bus.
/// </summary>
public sealed class EventBus : EventBus<IEvent>, IEventBus;

/// <summary>
/// Default implementation of a typed event bus.
/// </summary>
/// <typeparam name="TLowLevelEvent">The base type of events handled by this bus.</typeparam>
public class EventBus<TLowLevelEvent> : IEventBus<TLowLevelEvent> where TLowLevelEvent : IEvent
{
    private readonly List<IEventListener> m_Listeners = [];

    /// <inheritdoc/>
    public void Subscribe(IEventListener listener)
    {
        var listeners = m_Listeners;
        if(listeners.Contains(listener)) throw new InvalidOperationException();
        listeners.Add(listener);
        listeners.Sort();
    }

    /// <inheritdoc/>
    public void Unsubscribe(IEventListener listener)
    {
        var listeners = m_Listeners;
        if(!listeners.Remove(listener)) throw new InvalidOperationException();
        listeners.Sort();
    }

    /// <inheritdoc/>
    public void Dispatch<TEvent>(TEvent reason) where TEvent : TLowLevelEvent
    {
        foreach(var listener in m_Listeners)
        {
            if(listener is not IEventListener<TEvent> reasonListener) return;
            reasonListener.Listen(reason);
        }
    }
}