using SEB.Abstraction;
using System;
namespace SEB;
public class ScriptableEventListener(Type eventType, int order, ScriptableEventListener.Handler handler) : EventListenerBase {
 public delegate void Handler(IEvent reason);
 public override Type EventType {
  get {
   return eventType;
  }
 }
 public override int Order {
  get {
   return order;
  }
 }
 public override void Emit(IEvent reason) {
  handler?.Invoke(reason);
 }
}
public class ScriptableEventListener<TEvent>(int order, ScriptableEventListener<TEvent>.Handler handler) : EventListenerBase<TEvent> where TEvent : IEvent {
 public delegate void Handler(TEvent reason);
 public override Type EventType {
  get {
   return typeof(TEvent);
  }
 }
 public override int Order {
  get {
   return order;
  }
 }
 protected override void Emit(TEvent reason) {
  handler?.Invoke(reason);
 }
}