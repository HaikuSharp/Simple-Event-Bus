using System;
namespace SEB.Abstraction;
public interface IEventListener : IEventEmitter, IComparable<IEventListener> {
 Type EventType { get; }
 int Order { get; }
}
