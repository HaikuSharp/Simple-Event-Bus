namespace SEB.Abstraction;
public interface IEventEmitter {
 void Emit(IEvent reason);
}
public interface IEventEmitter<in TEvent> : IEventEmitter where TEvent : IEvent {
 void Emit(TEvent reason);
}
