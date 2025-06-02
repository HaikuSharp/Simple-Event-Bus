using SEB.Abstraction;
using Sugar.Object.Extensions;
using System;
using System.Collections.Generic;
namespace SEB;
public class EventBus : IEventBus {
 private readonly Dictionary<Type, EventListenersCache> m_CachedListeners = [];
 public IDisposable Subscribe(IEventListener lisener) {
  this.InternalAdd(lisener);
  return this.InternalCreateDisposable(lisener);
 }
 public void Unsubscribe(IEventListener lisener) {
  this.InternalRemove(lisener);
 }
 public void Emit(IEvent reason) {
  if(this.m_CachedListeners.TryGetValue(reason.Type, out var cache)) {
   cache.Emit(reason);
  }
 }
 private void InternalAdd(IEventListener listener) {
  this.InternalGetOrCreateCache(listener.EventType).Cache(listener);
 }
 private void InternalRemove(IEventListener listener) {
  this.InternalGetOrCreateCache(listener.EventType).Clear(listener);
 }
 private EventListenersCache InternalGetOrCreateCache(Type type) {
  if(this.m_CachedListeners.TryGetValue(type, out var cache)) {
   return cache;
  }
  cache = new();
  this.m_CachedListeners.Add(type, cache);
  return cache;
 }
 private EventListenerDisposeble InternalCreateDisposable(IEventListener listener) {
  return new EventListenerDisposeble(this, listener);
 }
 private class EventListenerDisposeble(IEventBus bus, IEventListener listener) : IDisposable {
  public void Dispose() {
   bus.Unsubscribe(listener);
  }
 }
 private class EventListenersCache : IEventEmitter {
  private readonly List<IEventListener> m_Cache = [];
  public void Emit(IEvent reason) {
   foreach(var listener in this.m_Cache) {
    listener.Listen(reason);
   }
  }
  internal void Cache(IEventListener listener) {
   if(!this.m_Cache.Contains(listener)) {
    this.m_Cache.Add(listener);
    this.m_Cache.Sort();
   }
  }
  internal void Clear(IEventListener listener) {
   if(this.m_Cache.Remove(listener)) {
    this.m_Cache.Sort();
   }
  }
 }
}
