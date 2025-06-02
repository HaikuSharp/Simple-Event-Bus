using SEB.Test.Types;
using Sugar.Object.Extensions;
namespace SEB.Test;
[TestClass]
public sealed class TestBus {
 [TestMethod]
 public void DoTest() {
  EventBus bus = new();

  bus.Subscribe(new Event0Listener(1)).Forget();
  bus.Subscribe(new Event0Listener(0)).Forget();
  bus.Subscribe(new Event1Listener(1)).Forget();
  bus.Subscribe(new Event1Listener(0)).Forget();

  bus.Emit(new Event0());
  bus.Emit(new Event1());
 }
}
