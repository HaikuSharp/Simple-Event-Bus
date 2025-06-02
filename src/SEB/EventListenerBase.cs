using SEB.Abstraction;
using Sugar.Object.Extensions;
namespace SEB;
public abstract class EventListenerBase : IEventListener {
 public abstract int Order { get; }
 public abstract bool Hear(IEvent reason);
 public abstract void Emit(IEvent reason);
 public int CompareTo(IEventListener other) {
  return this.Order.CompareTo(other.Order);
 }
}
public abstract class EventListenerBase<TEvent> : EventListenerBase where TEvent : IEvent {
 public override bool Hear(IEvent reason) {
  if(reason.Is<TEvent>(out var casted)) {
   return this.Hear(casted);
  }
  return false;
 }
 public override void Emit(IEvent reason) {
  if(reason.Is<TEvent>(out var casted)) {
   this.Emit(casted);
  }
 }
 protected virtual bool Hear(TEvent reason) {
  return true;
 }
 protected abstract void Emit(TEvent reason);
}
