---
layout: module
title: 02 — Records and generated equality
description: Records are not magic domain objects. Their most visible behavior is generated value-based equality.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo collections
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/01-identity-vs-value/
previous_label: Identity vs value
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/03-stable-dictionary-keys/
next_label: Stable dictionary keys
---

## Goal

Understand what changes when equality is generated from data.

A `record class` is still a reference type. It can still live on the heap and be passed by reference. The big modeling change is equality.

## The surprise

Start with a normal class:

```csharp
private sealed class ProductKeyClass
{
    public ProductKeyClass(string sku, string country)
    {
        Sku = sku;
        Country = country;
    }

    public string Sku { get; }
    public string Country { get; }
}
```

Now create two instances:

```csharp
var a = new ProductKeyClass("ABC", "FR");
var b = new ProductKeyClass("ABC", "FR");
```

They look equivalent to a human, but they are not equal by default. They are two different objects.

## Records change the question

```csharp
private sealed record ProductKeyRecord(string Sku, string Country);
```

Now two instances with the same SKU and country compare equal by content.

That is convenient, but it is not automatically correct. You still need to decide whether content equality is part of the domain concept.

## What record generates

For this module, remember the practical effects:

- generated `Equals`,
- generated `GetHashCode`,
- generated `ToString`,
- support for `with` expressions,
- value-based equality for records.

The important part for the next lesson is `Equals` and `GetHashCode`.

## Teaching moment

Before you run the sample, predict this:

```csharp
var a = new ProductKeyRecord("ABC", "FR");
var b = new ProductKeyRecord("ABC", "FR");
var set = new HashSet<ProductKeyRecord> { a, b };

Console.WriteLine(set.Count);
```

If the answer feels obvious, ask the same question with a class.

That small difference is where many collection bugs begin.

## Self-check

- What does a record generate that matters for collections?
- When would generated equality be wrong for a domain object?
- Why is `record class` not just a shorter `class`?
