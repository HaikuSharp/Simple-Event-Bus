using SEB.Abstraction;

namespace SEB;

/// <summary>
/// Base class for event implementations that provides default naming behavior.
/// </summary>
public abstract class EventBase : IEvent
{
    /// <summary>
    /// Gets the name of the event, which by default is the type name of the event class.
    /// </summary>
    /// <value>
    /// The fully qualified type name of the event implementation.
    /// </value>
    public virtual string Name => GetType().Name;
}