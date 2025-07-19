using SEB.Abstraction;
using System;

namespace SEB.Exceptions;

/// <summary>
/// Exception thrown when an event of an unexpected type is encountered.
/// </summary>
public class InvalidEventTypeException(Type current, Type required)
    : Exception($"Event type mismatch. Expected: '{required.FullName}', received: '{current.FullName}'")
{
    /// <summary>
    /// Validates that an event is of the required type and either returns it casted or throws.
    /// </summary>
    /// <typeparam name="TRequired">The expected event type.</typeparam>
    /// <param name="reason">The event to validate.</param>
    /// <returns>
    /// The event cast to <typeparamref name="TRequired"/> if the type matches.
    /// </returns>
    /// <exception cref="InvalidEventTypeException">
    /// Thrown when the event is not of the required type.
    /// </exception>
    public static TRequired ThrowIfIsNot<TRequired>(IEvent reason) where TRequired : IEvent
        => reason is TRequired t ? t : throw new InvalidEventTypeException(reason.GetType(), typeof(TRequired));
}