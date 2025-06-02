using System;
namespace SEB.Abstraction;
public interface IEventListener : IEventEmitter, IComparable<IEventListener> {
 int Order { get; }
 bool Hear(IEvent reason);
}
