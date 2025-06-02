using SEB.Abstraction;
using Sugar.Object.Extensions;
using System;
namespace SEB;
public abstract class EventHearingBase<TEvent> : IEventHearing<TEvent> where TEvent : IEvent {
 public abstract bool Hear(TEvent reason);
 bool IEventHearing.Hear(IEvent reason) {
  if(reason.Is<TEvent>(out var casted)) {
   return this.Hear(casted);
  }
  return false;
 }
}
