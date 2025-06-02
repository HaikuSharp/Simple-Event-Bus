using SEB.Abstraction;
using Sugar.Object.Extensions;
using System;
namespace SEB;
public abstract class EventListenerBase : IEventListener {
 public abstract Type EventType { get; }
 public abstract int Order { get; }
 public abstract void Listen(IEvent reason);
 public int CompareTo(IEventListener other) {
  return this.Order.CompareTo(other.Order);
 }
}
public abstract class EventListenerBase<TEvent> : EventListenerBase where TEvent : IEvent {
 public override Type EventType {
  get {
   return typeof(TEvent);
  }
 }
 public override void Listen(IEvent reason) {
  if(reason.Is<IEvent, TEvent>(out var casted)) {
   this.Listen(casted);
  }

 }
 protected abstract void Listen(TEvent reason);
}
