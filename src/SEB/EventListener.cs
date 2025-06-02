using SEB.Abstraction;
namespace SEB;
public class EventListener(int order, IEventHearing hearing, IEventEmitter emitter) : IEventListener {
 public int Order {
  get {
   return order;
  }
 }
 public bool Hear(IEvent reason) {
  return hearing.Hear(reason);
 }
 public void Emit(IEvent reason) {
  emitter.Emit(reason);
 }
 public int CompareTo(IEventListener other) {
  return this.Order.CompareTo(other.Order);
 }
}
