---
layout: module
title: 04 — Strongly typed IDs
description: Stop GUIDs from disguising themselves as each other.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo ids
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/03-stable-dictionary-keys/
previous_label: Stable dictionary keys
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/05-value-objects/
next_label: Value objects
---

## Goal

Use the compiler to prevent ID mix-ups.

## The problem

A `Guid` is a useful storage format, but it is a poor domain concept.

```csharp
void CancelOrder(Guid orderId);
```

This method says it needs an order ID, but the compiler only sees a `Guid`.

That means this can happen:

```csharp
Guid customerId = GetCustomerId();
CancelOrder(customerId); // compiles, but the concept is wrong
```

The value has the right shape and the wrong meaning.

## Better model

Wrap the primitive in a small type:

```csharp
public readonly record struct CustomerId(Guid Value);
public readonly record struct OrderId(Guid Value);
```

Now the method can ask for the real concept:

```csharp
public void CancelOrder(OrderId orderId)
```

Passing a `CustomerId` no longer compiles.

## Why this is useful

Strongly typed IDs are useful when:

- several IDs share the same primitive representation,
- a method accepts multiple IDs,
- the ID crosses architectural boundaries,
- confusing two IDs would create a meaningful bug.

They are less useful for short-lived local variables where the type adds ceremony without protection.

## Trade-offs

Typed IDs are not free. In real applications you need to decide how they map to:

- JSON,
- route parameters,
- database columns,
- ORM configuration,
- default values.

That does not make them bad. It means they are a modeling choice, not a decoration.

## Self-check

- Which ID mix-ups could compile in your current code?
- Which method signatures would become clearer with typed IDs?
- Where would serialization or database mapping need explicit support?
