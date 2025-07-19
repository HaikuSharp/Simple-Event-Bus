using SEB.Abstraction;
using System;

namespace SEB.Hearing;

/// <summary>
/// An event handler that filters events based on their name using equality comparison.
/// </summary>
public class EventNameHearing(IEquatable<string> equatable) : IEventHearing
{
    /// <summary>
    /// Determines whether to handle an event by comparing its name using the configured equality comparer.
    /// </summary>
    /// <param name="reason">The event to evaluate.</param>
    /// <returns>
    /// <c>true</c> if the event's name matches the comparer's criteria;
    /// <c>false</c> otherwise.
    /// </returns>
    public bool Hear(IEvent reason) => equatable.Equals(reason.Name);
}