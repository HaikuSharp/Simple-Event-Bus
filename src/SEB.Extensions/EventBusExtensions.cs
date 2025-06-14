using SEB.Abstraction;

namespace SEB.Extensions;

public static class EventBusExtensions
{
    public static void Emit(this IEventBus bus, IEventSource source) => bus.Emit(source.CreateReason());
}
