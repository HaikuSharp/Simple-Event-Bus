namespace SEB.Abstraction;

/// <summary>
/// Represents a provider that manages event listener subscriptions.
/// </summary>
public interface IEventListenerProvider
{
    /// <summary>
    /// Subscribes an event listener to receive events.
    /// </summary>
    /// <param name="listener">The listener to subscribe.</param>
    void Subscribe(IEventListener listener);

    /// <summary>
    /// Unsubscribes an event listener from receiving events.
    /// </summary>
    /// <param name="listener">The listener to unsubscribe.</param>
    void Unsubscribe(IEventListener listener);
}