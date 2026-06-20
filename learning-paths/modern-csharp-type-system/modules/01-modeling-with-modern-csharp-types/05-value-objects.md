---
layout: module
title: 05 — Value objects
description: Use Money to see how a value object protects business meaning.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo money
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/04-strongly-typed-ids/
previous_label: Strongly typed IDs
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/06-record-structs/
next_label: Mutability traps
---

## Goal

Recognize when a primitive value loses business meaning.

## The problem

A price is often modeled as a `decimal`.

```csharp
decimal price = 19.99m;
```

That is easy to store and easy to calculate with. It is also incomplete.

What currency is it? Can it be negative? Can we add it to another price in a different currency? Does equality include the currency?

When the primitive cannot answer those questions, the model leaks rules into random application code.

## Better model

A `Money` value can carry the amount and currency together:

```csharp
public readonly record struct Money(decimal Amount, string Currency);
```

Now the concept has a name. We can add behavior around it:

```csharp
public Money Add(Money other)
{
    if (Currency != other.Currency)
        throw new InvalidOperationException("Cannot add different currencies.");

    return new Money(Amount + other.Amount, Currency);
}
```

The type protects a rule that would otherwise be easy to forget.

## What makes a good value object

A good value object usually:

- represents one domain concept,
- is equal by content,
- is immutable or treated as immutable,
- protects one or more invariants,
- makes invalid operations visible.

Do not create value objects just to make code look more domain-driven. Create them when they prevent confusion.

## Teaching moment

Ask what bug the type prevents.

If the answer is vague, the type may be ceremony.

If the answer is concrete, the type is probably carrying useful design information.

## Self-check

- What invariant does `Money` protect?
- Should `Money(10, "EUR")` equal `Money(10, "USD")`?
- Which primitive in your code has hidden business rules around it?
