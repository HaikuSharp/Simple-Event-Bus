using SEB.Abstraction;

namespace SEB;

public class WrapEventEmitter(IEventEmitter root) : IEventEmitter
{
    public void Emit(IEvent reason) => root.Emit(reason);
}
