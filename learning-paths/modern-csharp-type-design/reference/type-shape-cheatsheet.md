# Type Shape Cheatsheet

A quick reference for the first course.

## `class`

Use when:

- the thing has identity;
- lifecycle matters;
- behavior and state change over time;
- shared mutable state is intentional.

Avoid when:

- two instances with the same data should naturally compare as equal;
- the type is only a small value wrapper.

Common trap:

- assuming two objects with the same property values are equal by default.

Example:

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
}
```

## `record class`

Use when:

- the type is data-oriented;
- equality by data is useful;
- the type is a DTO, command, event, message, or snapshot.

Avoid when:

- identity and lifecycle are the main concern;
- value-type copying is required.

Common trap:

- forgetting that `record class` is still a reference type.

Example:

```csharp
public sealed record UserDto(Guid Id, string Email, string DisplayName);
```

## `record struct`

Use when:

- mutation is intentional;
- value-type behavior is useful;
- the type is small and copying is acceptable.

Avoid when:

- the value should be stable after creation.

Common trap:

- `record struct` is mutable by default.

Example:

```csharp
public record struct Money(decimal Amount, string Currency);
```

## `readonly record struct`

Use when:

- the type is a small stable business value;
- the value should not change after creation;
- equality by data is useful.

Avoid when:

- the value owns mutable reference-type members without defensive copying or immutable collections.

Common trap:

- `readonly` is not deep immutability.

Example:

```csharp
public readonly record struct OrderId(Guid Value);
```

## `enum`

Use when:

- the value is a simple label;
- there is no state-specific data.

Avoid when:

- each state needs different required data.

Common trap:

- pairing an enum with many nullable properties and assuming the model is now safe.

Example:

```csharp
public enum SubscriptionStatus
{
    Trial,
    Active,
    Cancelled
}
```

## Record hierarchy

Use when:

- each state has different required data;
- pattern matching makes handling clearer;
- invalid combinations should be harder to represent.

Avoid when:

- an enum is enough;
- the external API contract must stay flat and simple without additional mapping.

Common trap:

- exposing the internal state hierarchy directly as JSON without designing the discriminator and wire contract.

Example:

```csharp
public abstract record SubscriptionState;

public sealed record Trial(DateTime EndsAt) : SubscriptionState;
public sealed record Active : SubscriptionState;
public sealed record Cancelled(DateTime CancelledAt) : SubscriptionState;
```
