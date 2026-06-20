---
layout: module
title: 02 — Records and generated equality
description: Records are not magic domain objects. Their most important behavior is generated value-based equality.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo collections
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/01-identity-vs-value/
previous_label: Identity vs value
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/03-stable-dictionary-keys/
next_label: Stable dictionary keys
---

## Goal

Understand what changes when a type uses generated equality.

## Why this matters

A `record class` gives you value-based equality, generated `Equals`, generated `GetHashCode`, and `with` expressions.

That changes how collections behave. It is especially visible in `HashSet<T>` and `Dictionary<TKey, TValue>`.

## Problem example

Two different `class` instances with the same constructor values are not equal by default:

```csharp
var a = new ProductKeyClass("ABC", "FR");
var b = new ProductKeyClass("ABC", "FR");
var set = new HashSet<ProductKeyClass> { a, b };
```

The set keeps both items because default class equality is reference equality.

## Better model

If content equality is part of the domain concept, a record can be useful:

```csharp
private sealed record ProductKeyRecord(string Sku, string Country);
```

Now two product keys with the same SKU and country compare equal by content.

## Trade-off

Records make equality convenient, but they do not decide whether equality is correct for your domain.

Use a record when value equality is part of the model. Use a class when identity matters.

## Self-check

- What does a record generate that matters for dictionaries?
- When would generated equality be wrong?
- When would a custom `IEqualityComparer<T>` be clearer than changing the model type?
