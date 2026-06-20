---
layout: module
title: 04 — Strongly typed IDs
description: Replace ambiguous primitive IDs with types the compiler can distinguish.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo ids
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/03-stable-dictionary-keys/
previous_label: Stable dictionary keys
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/05-value-objects/
next_label: Value objects
---

## Goal

Use small ID types to prevent accidental mix-ups.

## Why this matters

Primitive IDs are convenient, but several domain concepts can share the same primitive representation.

## Better model

```csharp
public readonly record struct CustomerId(Guid Value);
public readonly record struct OrderId(Guid Value);

public void CancelOrder(OrderId orderId) { }
```

Passing a `CustomerId` where an `OrderId` is expected no longer compiles.

## Use this when

- Several IDs share the same primitive representation.
- A method accepts multiple IDs.
- The ID crosses architectural boundaries.
- Confusing two IDs would create a meaningful bug.

## Be careful with

- serialization,
- ORM mapping,
- default values of structs,
- excessive wrapping for purely local variables.

## Self-check

- Which mistakes does the compiler now prevent?
- What does a strongly typed ID not solve?
- Where would serialization or mapping code be needed in a real application?
