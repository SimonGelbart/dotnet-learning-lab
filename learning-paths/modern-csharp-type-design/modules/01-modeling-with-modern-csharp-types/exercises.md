# Optional exercises

The core course is readable without local setup. These exercises are for learners who want to test the ideas after finishing the module.

## Exercise 1 - Classify the model

For each concept, choose a likely type shape and explain why.

```text
User
UserId
UserRegisteredEvent
EmailAddress
PaymentStatus
FailedPaymentState
Currency
```

Use the decision guide rather than guessing from syntax preference.

## Exercise 2 - Predict equality

Given this type:

```csharp
public sealed class ProductKey
{
    public ProductKey(string sku, string country)
    {
        Sku = sku;
        Country = country;
    }

    public string Sku { get; }
    public string Country { get; }
}
```

What does this print?

```csharp
var a = new ProductKey("ABC", "FR");
var b = new ProductKey("ABC", "FR");

Console.WriteLine(a == b);
Console.WriteLine(new HashSet<ProductKey> { a, b }.Count);
```

Then rewrite the type as a record and predict the result again.

## Exercise 3 - Find the unstable key

What is dangerous here?

```csharp
public record struct CartKey(string CustomerId, string Region);

var key = new CartKey("customer-1", "EU");
var carts = new Dictionary<CartKey, int>();

carts[key] = 1;
key.Region = "US";

Console.WriteLine(carts.ContainsKey(key));
```

Rewrite the type so the key is stable after creation.

## Exercise 4 - Replace primitive IDs

Start from this method:

```csharp
void CancelOrder(Guid customerId, Guid orderId)
```

Introduce strongly typed IDs and rewrite the signature.

Then answer:

- what mistake is now harder to make?
- what ceremony did you add?
- is the trade-off worth it for this boundary?

## Exercise 5 - Refactor subscription state

Start from the permissive model:

```csharp
public sealed class Subscription
{
    public bool IsTrial { get; set; }
    public bool IsActive { get; set; }
    public bool IsCancelled { get; set; }
    public DateTime? TrialEndsAt { get; set; }
    public DateTime? CancelledAt { get; set; }
}
```

Refactor it in two steps:

1. replace the three booleans with an enum;
2. replace the enum and nullable dates with dedicated state records.

Write one sentence explaining when the enum version would be enough.

## Exercise 6 - Design the JSON boundary

For the subscription state model, choose one external JSON shape.

Options:

- expose the polymorphic state directly with `kind`;
- expose a flat DTO with `status`, `trialEndsAt`, and `cancelledAt`;
- expose a different public contract and map internally.

Write down the trade-off you are accepting.
