using SEB.Abstraction;
using System;
using System.Collections.Generic;

namespace SEB;

public class EventBus : IEventBus
{
    private readonly List<IEventListener> m_Listeners = [];

    public IDisposable Subscribe(IEventListener listener)
    {
        InternalAdd(listener);
        return CreateDisposable(listener);
    }
    public void Unsubscribe(IEventListener listener) => InternalRemove(listener);

    public void Emit(IEvent reason)
    {
        foreach(IEventListener listener in m_Listeners)
        {
            if(!listener.Hear(reason)) continue;
            listener.Emit(reason);
        }
    }
    private void InternalAdd(IEventListener listener)
    {
        List<IEventListener> listeners = m_Listeners;
        if(listeners.Contains(listener)) return;
        listeners.Add(listener);
        listeners.Sort();
    }
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
