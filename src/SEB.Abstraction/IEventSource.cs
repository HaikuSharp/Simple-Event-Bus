namespace SEB.Abstraction;
public interface IEventSource {
 IEvent CreateReason();
}
public interface IEventSource<TEvent> : IEventSource where TEvent : IEvent {
 new TEvent CreateReason();
}
