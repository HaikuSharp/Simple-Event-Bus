using SEB.Abstraction;
using Sugar.Object.Extensions;
namespace SEB;
public abstract class EventBase : IEvent {
 public virtual string Name {
  get {
   return this.Type.Name;
  }
 }
}
