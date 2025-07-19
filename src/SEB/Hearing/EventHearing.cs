using SEB.Abstraction;

namespace SEB.Hearing;

/// <summary>
/// A generic base class for handling events of a specific type <typeparamref name="TEvent"/>.
/// </summary>
/// <typeparam name="TEvent">The type of event to handle, must implement <see cref="IEvent"/>.</typeparam>
public class EventHearing<TEvent> : IEventHearing<TEvent> where TEvent : IEvent
{
    /// <summary>
    /// The default singleton instance that accepts all events of type <typeparamref name="TEvent"/>.
    /// </summary>
    public static EventHearing<TEvent> Default => field ??= new();

    /// <summary>
    /// Determines whether to handle the specified typed event.
    /// </summary>
    /// <param name="reason">The event to evaluate.</param>
    /// <returns>
    /// Always returns <c>true</c> in the base implementation, indicating the event should be handled.
    /// Derived classes can override this to implement custom filtering logic.
    /// </returns>
    public virtual bool Hear(TEvent reason) => true;

    /// <summary>
    /// Determines whether to handle an event by checking if it's of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <param name="reason">The event to evaluate.</param>
    /// <returns>
    /// <c>true</c> if the event is of type <typeparamref name="TEvent"/> and <see cref="Hear(TEvent)"/> returns true;
    /// <c>false</c> otherwise.
    /// </returns>
    bool IEventHearing.Hear(IEvent reason) => reason is TEvent tevent && Hear(tevent);
}