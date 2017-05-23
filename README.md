# ravelin-csharp

C# library for the [Ravelin API](https://developer.ravelin.com). Ravelin is a fraud detection tool.

## Installation

```
PM> Install-Package Ravelin
```

## Quick Start

```csharp
var client = new RavelinClient("sk_live_XXXXXXXX");

var orderEvent = new OrderEvent
{
  CustomerId = "61283761287361",
  Order = new Order
  {
    OrderId = "n1QSYK0ceGNZqU28ien3",
    Price = 4675,
    Currency = "GBP",
    Items = new List<Item>
    {
      new Item
      {
        Sku = "3726-8",
        Name = "Women's Arch Sweater M 55",
        Price = 1990,
        Currency = "GBP",
        Quantity = 2
      }
    },
    CreationTimeUtc = DateTime.UtcNow,
    ExecutionTimeUtc = DateTime.UtcNow,
    Status = new OrderStatus { Stage = OrderStage.Pending, Actor = "buyer" }
  },
  DeviceId = "2b6f0cc904d137be2e1730235f5664094b831186"
};

var response = await client.SendEventAndScore(EventType.Order, orderEvent);

Console.WriteLine(scoredResponse.Score.Action); //ALLOW/REVIEW/PREVENT
```

For sample implementations, check the [.NET Core Example](https://github.com/stickytickets/ravelin-csharp/tree/master/examples/ExampleCore) and [.NET 4.5.1 Example](https://github.com/stickytickets/ravelin-csharp/tree/master/examples/ExampleNet451).
