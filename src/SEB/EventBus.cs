using SEB.Abstraction;
using System;
using System.Collections.Generic;
namespace SEB;
public class EventBus : IEventBus {
 private readonly List<IEventListener> m_Listeners = [];
 public IDisposable Subscribe(IEventListener listener) {
  this.InternalAdd(listener);
  return this.CreateDisposable(listener);
 }
 public void Unsubscribe(IEventListener listener) {
  this.InternalRemove(listener);
 }
 public void Emit(IEvent reason) {
  foreach(var listener in this.m_Listeners) {
   if(listener.Hear(reason)) {
    listener.Emit(reason);
   }
  }
 }
 private void InternalAdd(IEventListener listener) {
  var listeners = this.m_Listeners;
  if(!listeners.Contains(listener)) {
   listeners.Add(listener);
   listeners.Sort();
  }
 }
 private void InternalRemove(IEventListener listener) {
  var listeners = this.m_Listeners;
  if(listeners.Remove(listener)) {
   listeners.Sort();
  }
 }
 private EventListenerDisposable CreateDisposable(IEventListener listener) {
  return new EventListenerDisposable(this, listener);
 }
 private class EventListenerDisposable(IEventBus bus, IEventListener listener) : IDisposable {
  public void Dispose() {
   bus.Unsubscribe(listener);
  }
 }
}
