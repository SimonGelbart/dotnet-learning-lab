# 06 - JSON contracts

## Mission

Understand the cost of a stronger internal model at the wire boundary.

A stronger domain model can make application code safer, but public JSON needs an explicit contract.

## The problem

The record-state model is clear inside the application:

```csharp
public abstract record SubscriptionState;

public sealed record Trial(DateTime EndsAt) : SubscriptionState;
public sealed record Active : SubscriptionState;
public sealed record Cancelled(DateTime CancelledAt) : SubscriptionState;
```

But JSON consumers need a stable shape. If the state is polymorphic, the wire format usually needs a discriminator.

## One explicit JSON shape

For example:

```json
{
  "state": {
    "kind": "trial",
    "endsAt": "2026-07-01T00:00:00Z"
  }
}
```

```json
{
  "state": {
    "kind": "active"
  }
}
```

```json
{
  "state": {
    "kind": "cancelled",
    "cancelledAt": "2026-07-10T00:00:00Z"
  }
}
```

This is less flat than bools or enum fields, but it says exactly which data belongs to which state.

## Possible implementation direction

With `System.Text.Json`, you can make the discriminator explicit.

```csharp
[JsonPolymorphic(TypeDiscriminatorPropertyName = "kind")]
[JsonDerivedType(typeof(Trial), "trial")]
[JsonDerivedType(typeof(Active), "active")]
[JsonDerivedType(typeof(Cancelled), "cancelled")]
public abstract record SubscriptionState;
```

Do not treat this as the only possible implementation. The lesson is broader:

> Internal modeling and external contracts are related, but they do not have to be identical.

## Trade-off

A flat JSON model is easy to read, but may allow invalid combinations.

A stronger state model can make invalid combinations harder to represent, but the wire format needs deliberate design.

You may decide to:

- expose the polymorphic shape directly;
- map internal states to a flatter API DTO;
- keep an enum externally and a richer model internally.

The important part is to choose, not drift into an accidental contract.

## Check yourself

If your public API already exposes this shape:

```json
{
  "status": "cancelled",
  "trialEndsAt": null,
  "cancelledAt": "2026-07-10T00:00:00Z"
}
```

Does the internal model have to use the same shape?

No. You can map between an external DTO and an internal model if that keeps both sides clearer.

## Rule of thumb

JSON is a contract, not a side effect of your internal model.

Next: [Decision guide](07-decision-guide.md).
