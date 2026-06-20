---
layout: module
title: Module 01 — Modeling with modern C# types
description: Use C# types to express identity, value, equality, stable keys, small domain concepts, and valid state transitions.
permalink: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
source_url: https://github.com/SimonGelbart/dotnet-learning-lab/tree/main/learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types
---

This module adapts the first French talk, **Système de types C# moderne**, into learning-path format. The talk remains useful as presentation material; this module is meant to be followed asynchronously with samples, exercises, and self-check questions.

## Audience

This module is for developers who already write C# but want clearer rules for choosing between `class`, `record class`, `struct`, `record struct`, and `readonly record struct` in application and domain code.

You do not need advanced performance knowledge. The focus is modeling, correctness, and API clarity.

## Timebox

- Reading: 25–35 minutes.
- Running demos: 15–20 minutes.
- Exercises: 45–90 minutes.

## Learning objectives

By the end of this module, you should be able to:

- Explain the difference between identity and value.
- Choose between `class`, `record class`, `struct`, `record struct`, and `readonly record struct` for common backend scenarios.
- Predict how generated equality affects `HashSet<T>` and `Dictionary<TKey, TValue>`.
- Identify why mutable dictionary keys are dangerous.
- Replace ambiguous primitive IDs with strongly typed IDs.
- Use small value objects to encode domain constraints.
- Model state with explicit types instead of boolean flags and nullable fields.

## Core idea

A good type makes the valid path natural and the invalid path harder to write.

Modern C# features are not only syntax shortcuts. Used deliberately, they help communicate what a concept is:

- A long-lived entity with identity.
- A value that is equal by content.
- A small immutable key.
- A state that carries only the data that is valid for that state.

## Prerequisites

From the repository root:

```bash
dotnet build learning-paths/modern-csharp-type-system/src/DomainTypes.Samples
```

Run all module demos:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --all
```

Run one demo at a time:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo collections
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo ids
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo state-modeling
```

## Part 1 — Identity vs value

Start with this question:

> If two instances have the same data, should they be considered the same thing?

Use a `class` when the object has identity beyond its current data. Typical examples:

- `Customer`
- `Order`
- `ShoppingCart`
- `Subscription`
- Long-lived aggregate roots

Use a value type or record when equality by content is the main intent. Typical examples:

- `Money`
- `EmailAddress`
- `ProductKey`
- `CustomerId`
- `DateRange`
- `Coordinate`

A `class` says: this thing has identity. A `record` says: the data is part of what the thing means.

Demo:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo copying
```

Look for the difference between copying a reference and creating a modified copy of a value.

## Part 2 — Records are about equality, not magic

A `record class` gives you value-based equality, generated `Equals`, generated `GetHashCode`, and `with` expressions. That changes how collections behave.

Run:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo collections
```

Observe:

- Two different `class` instances with the same data are not equal by default.
- Two `record class` instances with the same data are equal by content.
- A dictionary does not become special because you used a record; it relies on equality and hash code behavior.

Rule of thumb:

- If content equality is part of the domain concept, a record may be useful.
- If object identity matters, stay with a class.
- If you use a class as a dictionary key, provide stable equality through `IEqualityComparer<T>` or override equality intentionally.

## Part 3 — Dictionary keys must be stable

Mutable keys are dangerous because hash-based collections assume the key does not change after insertion.

Run:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo mutable-key
```

The important lesson is not that records are unsafe. The lesson is that mutable state and hash-based lookup do not mix well.

A good key type should be:

- Small.
- Stable after creation.
- Clear about equality.
- Hard to accidentally confuse with another key.

This is where `readonly record struct` can be useful for small value objects and IDs.

## Part 4 — Strongly typed IDs

Primitive IDs are convenient, but they are easy to mix up:

```csharp
CancelOrder(Guid customerId); // compiles, but is conceptually wrong
```

A strongly typed ID makes the mistake visible to the compiler:

```csharp
public readonly record struct CustomerId(Guid Value);
public readonly record struct OrderId(Guid Value);
```

Run:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo ids
```

Use strongly typed IDs when:

- Several IDs share the same primitive representation.
- A method accepts multiple IDs.
- The ID crosses architectural boundaries.
- Confusing two IDs would create a meaningful bug.

Be careful with:

- Serialization.
- ORM mapping.
- Default values of structs.
- Excessive wrapping for purely local variables.

## Part 5 — Value objects

A value object is a small domain concept that is equal by value and should usually be immutable.

Run:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo money
```

`Money` is a good teaching example because the primitive representation is not enough:

- `decimal amount` alone loses the currency.
- Adding values with different currencies should not be allowed silently.
- Equality by content is useful.

A value object should usually protect one invariant or make one concept explicit. Do not create value objects just to make the code look “domain-driven.”

## Part 6 — `record struct` is mutable by default

This is one of the easiest traps in modern C#.

Run:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo record-struct
```

Prefer `readonly record struct` for small immutable values unless you have a specific reason to mutate the struct.

The `readonly` keyword does not make every referenced object deeply immutable. It mainly prevents mutation of the struct’s own fields/properties.

## Part 7 — Model states with types

Boolean flags and nullable fields can represent invalid combinations:

```csharp
IsTrial = true
IsActive = true
IsCancelled = true
TrialEndsAt = null
CancelledAt = null
```

An enum is often better, but it may still leave state-specific data disconnected from the state.

Run:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo state-modeling
```

The type-driven model expresses each valid state directly:

```csharp
public abstract record SubscriptionState;
public sealed record Trial(DateTime EndsAt) : SubscriptionState;
public sealed record Active : SubscriptionState;
public sealed record Cancelled(DateTime CancelledAt) : SubscriptionState;
```

This does not magically solve every business rule. It does make invalid state shapes harder to represent.

## Serialization note

Type-driven state models often need explicit serialization decisions.

Run:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo serialization
```

For public APIs and persistence, decide deliberately:

- What discriminator name do you use?
- Is the serialized shape stable?
- Can older clients read newer states?
- Are you exposing internal type names accidentally?

## Decision guide

| Situation | Prefer |
| --- | --- |
| Long-lived domain entity with identity | `class` |
| Immutable content-based data shape | `record class` |
| Small immutable value or key | `readonly record struct` |
| Performance-sensitive small value | `readonly struct` or `readonly record struct`, after measurement |
| Mutable stateful workflow object | `class` |
| Domain state with different data per state | record hierarchy or discriminated-style model |
| Dictionary key | stable immutable type with explicit equality |

## Exercises

### Exercise 1 — Replace primitive IDs

Take a service method that accepts multiple `Guid` parameters. Replace them with strongly typed IDs.

Before:

```csharp
void Transfer(Guid sourceAccountId, Guid destinationAccountId, Guid initiatedByUserId)
```

After:

```csharp
void Transfer(AccountId source, AccountId destination, UserId initiatedBy)
```

Self-check:

- Which mistakes does the compiler now prevent?
- What serialization or mapping code would you need in a real application?

### Exercise 2 — Fix a dictionary key

Create a dictionary keyed by a mutable class, mutate the key after insertion, and observe the lookup failure. Then refactor the key to a `readonly record struct`.

Use the `mutable-key` demo as a starting point.

### Exercise 3 — Model a state machine

Model an onboarding process with these states:

- `Invited(email, invitedAt)`
- `Registered(userId, registeredAt)`
- `Rejected(reason, rejectedAt)`

Avoid booleans such as `IsRegistered` and nullable fields such as `RegisteredAt?` on one big object.

Self-check:

- Which invalid combinations disappeared?
- Which business rules still need explicit validation?

## Self-check questions

- When should two objects with the same data still be different objects?
- What does a record generate that matters for dictionaries?
- Why is a mutable key dangerous after insertion into a dictionary?
- What problem do strongly typed IDs solve?
- What problem do they not solve?
- Why is `readonly record struct` usually safer than `record struct` for small value objects?
- What serialization decisions appear when you model states with a record hierarchy?

## Takeaways

- Types are design tools, not just containers for data.
- Records are most useful when equality by content is part of the concept.
- Stable keys matter more than clever key types.
- Strongly typed IDs reduce accidental mix-ups across APIs.
- State-specific types reduce invalid object shapes.
- Use modern C# features to make intent visible, not to make code look modern.

## Related material

- Talk source: `talks/01-modern-csharp-type-system-fr/`
- Samples: `src/DomainTypes.Samples/`
- Benchmarks: `src/DomainTypes.Benchmarks/`
