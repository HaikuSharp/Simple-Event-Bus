using SEB.Abstraction;
using System;

namespace SEB.Exceptions;

public class InvalidEventTypeException(Type current, Type required) : Exception($"Event type mismatch. Expected: '{required.FullName}', required: '{current.FullName}'")
{
    public static TRequired ThrowIfIsNot<TRequired>(IEvent reason) where TRequired : IEvent => reason is TRequired t ? t : throw new InvalidEventTypeException(reason.GetType(), typeof(TRequired));
}
