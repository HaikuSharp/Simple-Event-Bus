using System;

namespace SEB.Abstraction;

public interface IEventBus : IEventEmitter
{
    IDisposable Subscribe(IEventListener lisener);
    void Unsubscribe(IEventListener lisener);
}
