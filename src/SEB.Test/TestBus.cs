using SEB.Test.Types;
using Sugar.Object.Extensions;
namespace SEB.Test;
[TestClass]
public sealed class TestBus {
 [TestMethod]
 public void DoTest() {
  EventBus bus = new();

  // Custom Event0
  bus.Subscribe(new EventListener(1, new EventNameHearing("Custom #0"), new EventMessageEmitter("Hello c0 1."))).Forget(); // Second Invoke
  bus.Subscribe(new EventListener(0, new EventNameHearing("Custom #0"), new EventMessageEmitter("Hello c0 0."))).Forget(); // First Invoke

  // Custom Event1
  bus.Subscribe(new EventListener(1, new EventNameHearing("Custom #1"), new EventMessageEmitter("Hello c1 1."))).Forget(); // Second Invoke
  bus.Subscribe(new EventListener(0, new EventNameHearing("Custom #1"), new EventMessageEmitter("Hello c1 0."))).Forget(); // First Invoke

  bus.Emit(new Event0());
  bus.Emit(new Event1());
 }
}
