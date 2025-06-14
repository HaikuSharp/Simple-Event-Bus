using SEB.Abstraction;
using System;

namespace SEB;

public class EventNameHearing(IEquatable<string> equatable) : IEventHearing
{
    public bool Hear(IEvent reason) => equatable.Equals(reason.Name);
}