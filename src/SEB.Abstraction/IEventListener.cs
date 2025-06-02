using System;
namespace SEB.Abstraction;
public interface IEventListener : IEventEmitter, IEventHearing, IComparable<IEventListener> {
 int Order { get; }
}
