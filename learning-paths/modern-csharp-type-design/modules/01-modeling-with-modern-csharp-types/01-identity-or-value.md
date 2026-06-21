# 01 - Identity or value?

## Mission

Decide whether a model should behave like an entity, a data contract, or a small value.

Most type-design mistakes start before the first `if` statement. We choose a shape that says the wrong thing about the model.

The first question is simple:

> If two instances contain the same data, should they be considered the same thing?

## The problem

Imagine four names in a backend application:

```text
Customer
UserDto
OrderId
Money
```

They all hold data, but they do not mean the same kind of thing.

A `Customer` usually has identity. It can change email and still be the same customer.

A `UserDto` is a data shape sent across a boundary.

An `OrderId` is a tiny value that prevents one `Guid` from pretending to be another.

`Money` is a value with business meaning: amount and currency travel together.

## A useful first map

```text
class                  -> identity, lifecycle, behavior
record class           -> data-oriented reference type, value equality
readonly record struct -> small stable value
```

This is not a law. It is a starting signal.

## Identity: `class`

Use a `class` when the type represents an entity, service, lifecycle, or object with meaningful behavior over time.

```csharp
public sealed class Customer
{
    public Customer(Guid id, string email)
    {
        Id = id;
        Email = email;
    }

    public Guid Id { get; }
    public string Email { get; private set; }

    public void ChangeEmail(string email)
    {
        Email = email;
    }
}
```

Two customers may temporarily have the same email or display name. That does not make them the same entity.

## Data contract: `record class`

Use a `record class` when the type is mostly data and equality by data is useful.

```csharp
public sealed record UserDto(Guid Id, string Email, string DisplayName);

var user1 = new UserDto(Guid.NewGuid(), "alice@company.com", "Alice");
var user2 = user1 with { DisplayName = "Alice Martin" };
```

A `record class` is still a reference type. The difference is that the compiler generates value-based equality members for you.

## Small stable value: `readonly record struct`

Use a `readonly record struct` for small business values that should not change after creation.

```csharp
public readonly record struct OrderId(Guid Value);
public readonly record struct ProductKey(string Sku, string Country);
```

This says:

- this is a value;
- equality comes from the data;
- the positional properties cannot be reassigned after creation;
- the intent is visible in method signatures.

## Check yourself

Classify each name. Do you expect identity, data, small value, or state?

```text
Invoice
InvoiceId
InvoicePaidEvent
SubscriptionStatus
Price
```

Suggested answer:

- `Invoice`: identity/lifecycle, likely `class`.
- `InvoiceId`: small stable value, likely `readonly record struct`.
- `InvoicePaidEvent`: data message, likely `record class`.
- `SubscriptionStatus`: simple label if no attached data, likely `enum`.
- `Price`: value with business meaning, likely `readonly record struct` or richer value object.

## Rule of thumb

Choose the type shape for the behavior you want readers and callers to assume.

Next: [Equality becomes visible](02-equality-becomes-visible.md).
