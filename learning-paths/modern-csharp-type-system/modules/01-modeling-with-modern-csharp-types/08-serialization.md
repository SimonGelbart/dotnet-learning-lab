---
layout: module
title: 08 — Serialization contracts
description: A strong internal model is not automatically a good external contract.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo serialization
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/07-type-driven-state-modeling/
previous_label: Type-driven state modeling
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/09-decision-guide/
next_label: Decision guide
---

## Goal

Choose the external shape deliberately when internal models become richer.

## The new question

The state model is now stronger inside the application.

But what should leave the application?

A public API, database row, event payload, or cache entry is a contract. If it accidentally mirrors internal type names, refactoring becomes a breaking change.

## Type-rich internal model

Inside the application, this can be expressive:

```csharp
public abstract record SubscriptionState;
public sealed record Trial(DateTime EndsAt) : SubscriptionState;
public sealed record Active : SubscriptionState;
public sealed record Cancelled(DateTime CancelledAt) : SubscriptionState;
```

## Possible serialized shapes

A serialized contract might use an explicit discriminator:

```json
{
  "state": "trial",
  "trialEndsAt": "2026-07-01T00:00:00Z"
}
```

Another state can have a different shape:

```json
{
  "state": "cancelled",
  "cancelledAt": "2026-06-20T00:00:00Z"
}
```

That may be readable, but it must be chosen deliberately.

## Contract questions

Before exposing the model, decide:

- What discriminator name do you use?
- Is the serialized shape stable?
- Can older clients read newer states?
- Are you exposing internal type names accidentally?
- Should persistence use the same shape as the public API?

## Practical rule

Use rich internal types to make application code safer. Use explicit DTOs or explicit serialization rules to keep contracts stable.

## Self-check

- Which parts of the internal model are safe to expose?
- Which parts are implementation details?
- Would a flat DTO be clearer for clients?
