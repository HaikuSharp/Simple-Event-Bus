using System;
namespace SEB.Abstraction;
public interface IEventListener : IComparable<IEventListener> {
 Type EventType { get; }
 int Order { get; }
 void Listen(IEvent reason);
}
