using System;

namespace SEB.Tests;

public class LowLevelEventListener : EventListenerBase<ILowLevelEvent>
{
    public override int Order => 10;

    public override void Listen<TEvent>(TEvent reason)
    {
        Console.WriteLine("Low Level");
    }
}
