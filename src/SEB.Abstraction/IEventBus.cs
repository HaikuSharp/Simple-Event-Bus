namespace SEB.Abstraction;

/// <summary>
/// Represents a typed event bus that combines event dispatching and listener management capabilities.
/// </summary>
/// <typeparam name="TLowLevelEvent">The base type of events handled by this bus.</typeparam>
public interface IEventBus<in TLowLevelEvent> : IEventDispatcher<TLowLevelEvent>, IEventListenerProvider where TLowLevelEvent : IEvent;

/// <summary>
/// Represents an untyped event bus that handles events of any type.
/// </summary>
public interface IEventBus : IEventDispatcher<IEvent>, IEventListenerProvider;