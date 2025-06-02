using SEB.Abstraction;
namespace SEB;
public class EventEmitter(IEventEmitter root) : IEventEmitter {
 public void Emit(IEvent reason) {
  root.Emit(reason);
 }
}
