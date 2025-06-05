using SEB.Abstraction;
using Sugar.Object.Extensions;
namespace SEB;
public class EventHearing<TEvent> : IEventHearing where TEvent : IEvent {
 public bool Hear(IEvent reason) {
  return reason.Is<TEvent>();
 }
}