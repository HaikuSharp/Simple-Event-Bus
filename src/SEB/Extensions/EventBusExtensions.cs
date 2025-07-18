using SEB.Abstraction;
using SEB.Hearing;
using System;

namespace SEB.Extensions;

public static class EventBusExtensions
{
    public static IDisposable Subscribe<TEvent>(this IEventBus bus, IEventEmitter<TEvent> emitter) where TEvent : IEvent => bus.Subscribe(EventHearing<TEvent>.Default, emitter);

    public static IDisposable Subscribe<TEvent>(this IEventBus bus, IEventHearing<TEvent> hearing, IEventEmitter<TEvent> emitter) where TEvent : IEvent => bus.Subscribe(hearing, emitter, 0);

    public static IDisposable Subscribe<TEvent>(this IEventBus bus, IEventHearing<TEvent> hearing, IEventEmitter<TEvent> emitter, int order) where TEvent : IEvent => bus.Subscribe(hearing, emitter, order);

    public static IDisposable Subscribe(this IEventBus bus, IEventHearing hearing, IEventEmitter emitter) => bus.Subscribe(hearing, emitter, 0);

    public static IDisposable Subscribe(this IEventBus bus, IEventHearing hearing, IEventEmitter emitter, int order) => bus.Subscribe(new EventListener(hearing, emitter, order));

    public static void Emit(this IEventBus bus, IEventSource source) => bus.Emit(source.CreateReason());
}
