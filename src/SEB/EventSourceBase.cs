using SEB.Abstraction;
namespace SEB;
public abstract class EventSourceBase<TEvent> : IEventSource<TEvent> where TEvent : IEvent {
 public abstract TEvent CreateReason();
 IEvent IEventSource.CreateReason() {
  return this.CreateReason();
 }
}