using SEB.Abstraction;

namespace SEB;

/// <summary>
/// An event listener that uses a delegate for event handling.
/// </summary>
/// <typeparam name="TLowLevelEvent">The base type of events handled by this listener.</typeparam>
public class ScriptableEventListener<TLowLevelEvent>(int order, ScriptableEventListener<TLowLevelEvent>.EventDispatcher dispatcher) : EventListenerBase<TLowLevelEvent> where TLowLevelEvent : IEvent
{
    /// <summary>
    /// Delegate for handling events.
    /// </summary>
    /// <param name="lowLevelEvent">The event to handle.</param>
    public delegate void EventDispatcher(TLowLevelEvent lowLevelEvent);

    /// <inheritdoc/>
    public override int Order => order;

    /// <inheritdoc/>
    public override void Listen<TEvent>(TEvent reason) => dispatcher(reason);
}