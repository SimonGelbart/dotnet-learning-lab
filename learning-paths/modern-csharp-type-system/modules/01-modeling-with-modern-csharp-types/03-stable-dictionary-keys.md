---
layout: module
title: 03 — Stable dictionary keys
description: Hash-based collections assume a key stays stable after insertion.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo mutable-key
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/02-records-and-equality/
previous_label: Records and equality
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/04-strongly-typed-ids/
next_label: Strongly typed IDs
---

## Goal

Understand why dictionary keys must be stable.

## Why this matters

`Dictionary<TKey, TValue>` and `HashSet<T>` use equality and hash codes to find items. If the data used by equality changes after insertion, lookup can fail.

The lesson is not that records are unsafe. The lesson is that changing key data after insertion is unsafe.

## Better model

A good key type should be small, stable after creation, clear about equality, and hard to confuse with another key.

For small keys, `readonly record struct` can be a useful default:

```csharp
public readonly record struct ProductKey(string Sku, string Country);
```

## Self-check

- Why is a mutable key dangerous after insertion into a dictionary?
- Which fields are allowed to change on your key types?
- Would a `readonly record struct` make the key clearer?
