---
layout: module
title: 03 — Stable dictionary keys
description: Equality becomes operational when values enter HashSet and Dictionary.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo collections
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/02-records-and-equality/
previous_label: Records and equality
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/04-strongly-typed-ids/
next_label: Strongly typed IDs
---

## Goal

See why equality is not theoretical. Collections turn equality choices into runtime behavior.

## HashSet question

Imagine a price catalog key made of SKU and country.

```csharp
var a = new ProductKeyClass("ABC", "FR");
var b = new ProductKeyClass("ABC", "FR");
var set = new HashSet<ProductKeyClass> { a, b };
```

How many items are in the set?

With a normal class, the answer is usually two. The two objects have the same data, but default equality is reference equality.

Now ask the same question with a record:

```csharp
var a = new ProductKeyRecord("ABC", "FR");
var b = new ProductKeyRecord("ABC", "FR");
var set = new HashSet<ProductKeyRecord> { a, b };
```

This time the answer is one, because generated equality uses the data.

## Dictionary lookup surprise

The same idea appears in dictionaries.

```csharp
var prices = new Dictionary<ProductKeyClass, decimal>();
prices[new ProductKeyClass("ABC", "FR")] = 19.99m;

var found = prices.ContainsKey(new ProductKeyClass("ABC", "FR"));
```

A human sees the same key. The dictionary sees a different object.

You can solve that with a custom `IEqualityComparer<T>`, or by using a type whose equality already matches the concept.

```csharp
private readonly record struct ProductKeyValue(string Sku, string Country);
```

## The mutable key trap

A dictionary key must not change after insertion. If the data used by equality or hash code changes, lookup can fail.

That is why the rule is stronger than “use records”.

The rule is:

> A dictionary key must have stable equality.

A good key type is:

- small,
- immutable after creation,
- clear about equality,
- hard to confuse with another key.

## Self-check

- Why does `HashSet<class>` keep both equivalent-looking objects?
- Why does `Dictionary<TKey,TValue>` fail to find an equivalent class key?
- When would you choose a comparer instead of changing the key type?
- Why is mutability dangerous after insertion?
