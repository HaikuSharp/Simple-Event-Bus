using SEB.Abstraction;

namespace SEB;

/// <summary>
/// A basic implementation of <see cref="IEventListener"/> that delegates event handling and emission
/// to separate components while maintaining a defined order.
/// </summary>
/// <remarks>
/// This class acts as an adapter between <see cref="IEventHearing"/> and <see cref="IEventEmitter"/>
/// implementations while providing ordering capability.
/// </remarks>
public class EventListener(IEventHearing hearing, IEventEmitter emitter, int order) : IEventListener
{
    /// <summary>
    /// Gets the priority order of this listener relative to other listeners.
    /// </summary>
    /// <remarks>
    /// Lower values indicate higher priority in event processing order.
    /// </remarks>
    public int Order => order;

    /// <summary>
    /// Delegates event handling to the configured <see cref="IEventHearing"/> instance.
    /// </summary>
    /// <param name="reason">The event to process.</param>
    /// <returns>
    /// The result from the underlying <see cref="IEventHearing.Hear"/> implementation.
    /// </returns>
    public bool Hear(IEvent reason) => hearing.Hear(reason);

    /// <summary>
    /// Delegates event emission to the configured <see cref="IEventEmitter"/> instance.
    /// </summary>
    /// <param name="reason">The event to emit.</param>
    public void Emit(IEvent reason) => emitter.Emit(reason);

    /// <summary>
    /// Compares this listener's order with another listener's order.
    /// </summary>
    /// <param name="other">The other listener to compare with.</param>
    /// <returns>
    /// A value indicating the relative order of the listeners:
    /// <list type="bullet">
    /// <item><description>Less than zero - This listener has higher priority</description></item>
    /// <item><description>Zero - Equal priority</description></item>
    /// <item><description>Greater than zero - This listener has lower priority</description></item>
    /// </list>
    /// </returns>
    public int CompareTo(IEventListener other) => Order.CompareTo(other.Order);
}