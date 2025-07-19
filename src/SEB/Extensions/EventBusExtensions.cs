using SEB.Abstraction;
using SEB.Hearing;
using System;

namespace SEB.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IEventBus"/> to simplify common event bus operations.
/// </summary>
public static class EventBusExtensions
{
    /// <summary>
    /// Subscribes an emitter to handle all events of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to handle.</typeparam>
    /// <param name="bus">The event bus.</param>
    /// <param name="emitter">The emitter to subscribe.</param>
    /// <returns>A disposable subscription.</returns>
    public static IDisposable Subscribe<TEvent>(this IEventBus bus, IEventEmitter<TEvent> emitter) where TEvent : IEvent => bus.Subscribe(EventHearing<TEvent>.Default, emitter);

    /// <summary>
    /// Subscribes a hearing/emitter pair to handle events of type <typeparamref name="TEvent"/> with default priority.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to handle.</typeparam>
    /// <param name="bus">The event bus.</param>
    /// <param name="hearing">The event handler.</param>
    /// <param name="emitter">The event emitter.</param>
    /// <returns>A disposable subscription.</returns>
    public static IDisposable Subscribe<TEvent>(this IEventBus bus, IEventHearing<TEvent> hearing, IEventEmitter<TEvent> emitter) where TEvent : IEvent => bus.Subscribe(hearing, emitter, 0);

    /// <summary>
    /// Subscribes a hearing/emitter pair to handle events of type <typeparamref name="TEvent"/> with specified priority.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to handle.</typeparam>
    /// <param name="bus">The event bus.</param>
    /// <param name="hearing">The event handler.</param>
    /// <param name="emitter">The event emitter.</param>
    /// <param name="order">The listener priority (lower values = higher priority).</param>
    /// <returns>A disposable subscription.</returns>
    public static IDisposable Subscribe<TEvent>(this IEventBus bus, IEventHearing<TEvent> hearing, IEventEmitter<TEvent> emitter, int order) where TEvent : IEvent => bus.Subscribe(hearing, emitter, order);

    /// <summary>
    /// Subscribes a hearing/emitter pair to handle events with default priority.
    /// </summary>
    /// <param name="bus">The event bus.</param>
    /// <param name="hearing">The event handler.</param>
    /// <param name="emitter">The event emitter.</param>
    /// <returns>A disposable subscription.</returns>
    public static IDisposable Subscribe(this IEventBus bus, IEventHearing hearing, IEventEmitter emitter) => bus.Subscribe(hearing, emitter, 0);

    /// <summary>
    /// Subscribes a hearing/emitter pair to handle events with specified priority.
    /// </summary>
    /// <param name="bus">The event bus.</param>
    /// <param name="hearing">The event handler.</param>
    /// <param name="emitter">The event emitter.</param>
    /// <param name="order">The listener priority (lower values = higher priority).</param>
    /// <returns>A disposable subscription.</returns>
    public static IDisposable Subscribe(this IEventBus bus, IEventHearing hearing, IEventEmitter emitter, int order) => bus.Subscribe(new EventListener(hearing, emitter, order));

    /// <summary>
    /// Emits an event created from the specified source.
    /// </summary>
    /// <param name="bus">The event bus.</param>
    /// <param name="source">The event source.</param>
    public static void Emit(this IEventBus bus, IEventSource source) => bus.Emit(source.CreateReason());
}