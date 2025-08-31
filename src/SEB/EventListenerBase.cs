using SEB.Abstraction;

namespace SEB;

/// <summary>
/// Base class for implementing event listeners with default ordering.
/// </summary>
/// <typeparam name="TLowLevelEvent">The base type of events handled by this listener.</typeparam>
public abstract class EventListenerBase<TLowLevelEvent> : IEventListener<TLowLevelEvent> where TLowLevelEvent : IEvent
{
    /// <inheritdoc/>
    public virtual int Order => 0;

    /// <inheritdoc/>
    public int CompareTo(IEventListener other) => Order.CompareTo(other.Order);

    /// <inheritdoc/>
    public abstract void Listen<TEvent>(TEvent reason) where TEvent : TLowLevelEvent;
}