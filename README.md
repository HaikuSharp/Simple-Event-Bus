# Simple Event Bus (SEB)

Simple Event Bus (SEB) — это простая и легковесная библиотека для реализации шаблона "Шина событий" в .NET приложениях. Она предоставляет механизм для публикации и подписки на события с поддержкой порядка обработчиков и фильтрации событий.

## Основные концепции

### 1. Типы событий
Создавайте свои типы событий, реализуя интерфейс `IEvent`:

```csharp
public class UserCreatedEvent : IEvent
{
    public string UserId { get; init; } // ID пользователя
    public DateTime CreatedAt { get; init; } // Время создания
}

public class OrderProcessedEvent : IEvent
{
    public string OrderId { get; init; } // ID заказа
    public decimal Amount { get; init; } // Сумма заказа
}
```

### 2. Фильтры событий
Создавайте фильтры, наследуясь от `EventHearingBase<T>`:

```csharp
public class HighValueOrderHearing : EventHearingBase<OrderProcessedEvent>
{
    public override bool Hear(OrderProcessedEvent reason)
    {
        // Обрабатываем только заказы с суммой > 1000
        return reason.Amount > 1000;
    }
}
```

### 3. Обработчики событий
Создавайте обработчики, наследуясь от `EventEmitterBase<T>`:

```csharp
public class OrderNotificationEmitter : EventEmitterBase<OrderProcessedEvent>
{
    public override void Emit(OrderProcessedEvent reason)
    {
        // Логика обработки заказа
        Console.WriteLine($"Обработка заказа {reason.OrderId}");
        // Можно добавить дополнительную бизнес-логику
    }
}
```

## Пример

1. Создаем шину событий:
```csharp
var bus = new EventBus();
```

2. Создаем и регистрируем обработчик:
```csharp
var orderListener = new EventListener(
    order: 0, // Высокий приоритет
    hearing: new HighValueOrderHearing(),
    emitter: new OrderNotificationEmitter()
);

// Подписываемся и получаем объект для управления подпиской
var subscription = bus.Subscribe(orderListener);
```

3. Публикуем события:
```csharp
bus.Emit(new OrderProcessedEvent {
    OrderId = "ORD-123",
    Amount = 1500.00m
});
```

4. Отписка (опционально):
```csharp
subscription.Dispose();
// или bus.Unsubscribe(orderListener);
```
