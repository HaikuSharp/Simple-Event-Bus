namespace SEB.Abstraction;

/// <summary>
/// Represents a source that can generate events.
/// </summary>
public interface IEventSource
{
    /// <summary>
    /// Creates a new event instance.
    /// </summary>
    /// <returns>
    /// A new <see cref="IEvent"/> instance ready for emission.
    /// </returns>
    IEvent CreateReason();
}