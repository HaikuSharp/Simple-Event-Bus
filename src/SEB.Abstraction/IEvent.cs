namespace SEB.Abstraction;

/// <summary>
/// Represents a generic event in the event-based system.
/// </summary>
public interface IEvent
{
    /// <summary>
    /// Gets the name identifying the type of event.
    /// </summary>
    /// <value>
    /// A string that uniquely identifies the event type.
    /// </value>
    string Name { get; }
}