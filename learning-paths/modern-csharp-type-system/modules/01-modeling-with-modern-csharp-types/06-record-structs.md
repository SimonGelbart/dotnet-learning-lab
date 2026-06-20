---
layout: module
title: 06 — Mutability traps
description: Modern syntax does not automatically make a model immutable or safe.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo record-struct
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/05-value-objects/
previous_label: Value objects
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/07-type-driven-state-modeling/
next_label: Type-driven state modeling
---

## Goal

Avoid assuming that modern C# syntax automatically gives you deep immutability.

## Shallow immutability

A record can make the object shape feel stable, but immutability is often shallow.

If a record contains a mutable list, the record reference can be stable while the list contents still change.

```csharp
public sealed record OrderSummary(IReadOnlyList<string> Lines);
```

The property is read-only, but the object behind it may still be mutable depending on what was passed in.

The fridge is closed, but the food inside may still move.

## record struct is mutable by default

This is another easy trap:

```csharp
public record struct ProductKey(string Sku, string Country);
```

A positional `record struct` is mutable by default. That is surprising if you intended to create a stable value or dictionary key.

Prefer this when the value should not change:

```csharp
public readonly record struct ProductKey(string Sku, string Country);
```

## Connect this back to dictionaries

The previous lessons showed that dictionaries rely on stable equality.

If a key can mutate after insertion, the dictionary may no longer find it. The type may look modern, but the collection still breaks.

## Practical rule

For small domain values and keys, start with:

```csharp
public readonly record struct SomethingId(Guid Value);
public readonly record struct ProductKey(string Sku, string Country);
```

Then relax the rule only when you have a specific reason.

## Self-check

- Does `readonly` make referenced objects deeply immutable?
- Why is `record struct` mutable by default surprising?
- Which of your value types could be used as dictionary keys?
