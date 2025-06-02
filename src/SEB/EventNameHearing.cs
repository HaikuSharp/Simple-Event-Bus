using SEB.Abstraction;
using System;
namespace SEB;
public class EventNameHearing(IEquatable<string> equatable) : IEventHearing {
 public bool Hear(IEvent reason) {
  return equatable.Equals(reason.Name);
 }
}