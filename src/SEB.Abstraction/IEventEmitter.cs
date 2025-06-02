namespace SEB.Abstraction;

public interface IEventEmitter{
 void Emit(IEvent reason);
}