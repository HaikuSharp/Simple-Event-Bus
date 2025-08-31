using System;

namespace SEB.Tests;

public class HighLevelEventListener : EventListenerBase<HighLevelEvent>
{
    public override void Listen<TEvent>(TEvent reason)
    {
        Console.WriteLine("High Level");
    }
}
