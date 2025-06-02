using SEB.Abstraction;
using Sugar.Object.Extensions;
namespace SEB;
public abstract class EventEmitterBase<TEvent> : IEventEmitter<TEvent> where TEvent : IEvent {
 public abstract void Emit(TEvent reason);
 void IEventEmitter.Emit(IEvent reason) {
  if(reason.Is<TEvent>(out var casted)) {
   this.Emit(casted);
  }
 }
}
