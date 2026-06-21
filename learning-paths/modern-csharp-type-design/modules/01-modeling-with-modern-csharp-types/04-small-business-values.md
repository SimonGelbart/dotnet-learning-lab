# 04 - Small business values

## Mission

Replace fragile conventions with types.

A primitive value often needs a name before it becomes safe.

## Strongly typed IDs

Two IDs can share the same underlying representation without meaning the same thing.

```csharp
public readonly record struct CustomerId(Guid Value);
public readonly record struct OrderId(Guid Value);

public void CancelOrder(OrderId orderId)
{
    Console.WriteLine($"Cancelling {orderId.Value}");
}
```

This compiles:

```csharp
CancelOrder(new OrderId(Guid.NewGuid()));
```

This does not:

```csharp
var customerId = new CustomerId(Guid.NewGuid());
CancelOrder(customerId);
```

That is the point. The compiler is now helping enforce the difference between customer identity and order identity.

## Value object: `Money`

A value object can keep small business rules close to the data.

```csharp
public readonly record struct Money(decimal Amount, string Currency)
{
    public Money Add(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException("Different currencies.");

        return this with { Amount = Amount + other.Amount };
    }
}
```

`10 EUR` and `10 USD` are both numbers with strings, but they are not interchangeable business values.

## Why not just pass primitives?

This method is easy to call incorrectly:

```csharp
void Pay(Guid orderId, decimal amount, string currency)
```

This one carries more meaning:

```csharp
void Pay(OrderId orderId, Money amount)
```

The second signature tells the caller what the values are.

## The mutable `record struct` warning

This looks similar, but behaves differently:

```csharp
public record struct Money(decimal Amount, string Currency);

var price = new Money(10, "EUR");
price.Amount = -999;
price.Currency = "";
```

`record struct` is mutable by default. For small stable business values, prefer `readonly record struct` unless mutation is intentional.

## Trade-off

Small wrappers create more types. That is good when the type removes ambiguity. It is noise when the wrapper adds no meaning, no safety, and no rule.

Use small value types for concepts that appear in signatures, collections, or business rules.

## Check yourself

Which signature is harder to misuse?

```csharp
void Transfer(Guid fromAccountId, Guid toAccountId, decimal amount, string currency)
```

or:

```csharp
void Transfer(AccountId from, AccountId to, Money amount)
```

The second one is not perfect, but it expresses more intent before the method body starts.

## Rule of thumb

Wrap primitives when the name and the type prevent a real mistake.

Next: [Modeling valid states](05-modeling-valid-states.md).
