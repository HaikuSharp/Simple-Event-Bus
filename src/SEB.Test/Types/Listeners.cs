using System;
namespace SEB.Test.Types;
public class Event0Listener(int order) : EventListenerBase<Event0> {
 public override int Order {
  get {
   return order;
  }
 }
 protected override void Listen(Event0 reason) {
  Console.WriteLine($"Hello, My order is {order}");
 }
}
public class Event1Listener(int order) : EventListenerBase<Event1> {
 public override int Order {
  get {
   return order;
  }
 }
 protected override void Listen(Event1 reason) {
  Console.WriteLine($"Bye, My order was {order}");
 }
}
