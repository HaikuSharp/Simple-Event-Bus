using SEB.Abstraction;
using System;
namespace SEB.Test.Types;
public class EventMessageEmitter(string message) : IEventEmitter {
 public void Emit(IEvent reason) {
  Console.WriteLine(message);
 }
}
