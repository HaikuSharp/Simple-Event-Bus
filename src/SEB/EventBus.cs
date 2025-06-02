using SEB.Abstraction;
using Sugar.Object.Extensions;
using System;
using System.Collections.Generic;
namespace SEB;
public class EventBus : IEventBus {
 private readonly List<IEventListener> m_Listeners = [];
 public IDisposable Subscribe(IEventListener lisener) {
  this.InternalAdd(lisener);
  return this.CreateDisposable(lisener);
 }
 public void Unsubscribe(IEventListener lisener) {
  this.InternalRemove(lisener);
 }
 public void Emit(IEvent reason) {
  foreach(var listener in this.m_Listeners) {
   var type = reason.Type;
   if(type.IsAssignableFrom(listener.EventType)) {
    listener.Listen(reason);
   }
  }
 }
 private void InternalAdd(IEventListener listener) {
  if(!this.m_Listeners.Contains(listener)) {
   this.m_Listeners.Add(listener);
   this.m_Listeners.Sort();
  }
 }
 private void InternalRemove(IEventListener listener) {
  if(this.m_Listeners.Remove(listener)) {
   this.m_Listeners.Sort();
  }
 }
 private EventListenerDisposeble CreateDisposable(IEventListener listener) {
  return new EventListenerDisposeble(this, listener);
 }
 private class EventListenerDisposeble(IEventBus bus, IEventListener listener) : IDisposable {
  public void Dispose() {
   bus.Unsubscribe(listener);
  }
 }
}
