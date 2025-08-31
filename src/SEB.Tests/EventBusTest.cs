namespace SEB.Tests;

[TestClass]
public sealed class EventBusTest
{
    [TestMethod]
    public void DoTest()
    {
        EventBus bus = new();

        bus.Subscribe(new LowLevelEventListener());
        bus.Subscribe(new HighLevelEventListener());

        bus.Dispatch(new HighLevelEvent());
    }
}
