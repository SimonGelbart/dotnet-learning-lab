---
layout: module
title: 06 — record struct vs readonly record struct
description: Prefer readonly record struct for small immutable values.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo record-struct
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/05-value-objects/
previous_label: Value objects
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/07-type-driven-state-modeling/
next_label: Type-driven state modeling
---

## Goal

Avoid accidental mutability in small value types.

## Why this matters

A positional `record struct` is mutable by default. That can be surprising when you wanted a stable value.

## Better model

Prefer `readonly record struct` for small immutable values unless you have a specific reason to mutate the struct.

```csharp
public readonly record struct ProductKey(string Sku, string Country);
```

`readonly` mainly prevents mutation of the struct's own fields and properties.

## Self-check

- Why is `readonly record struct` usually safer?
- What does `readonly` not protect you from?
- Could this type ever be used as a dictionary key?
