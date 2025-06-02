using SEB.Abstraction;
namespace SEB.Extensions;
public static class EventBusExtensions {
 extension(IEventBus bus) {
  public void Emit(IEventSource source) {
   bus.Emit(source.CreateReason());
  }
 }
}
