---
layout: module
title: 01 — Identity vs value
description: Start with the modeling question that determines whether a type should behave like an entity or a value.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo copying
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
previous_label: Module overview
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/02-records-and-equality/
next_label: Records and equality
---

## Goal

Learn to ask the first useful type-design question:

> If two instances have the same data, should they be considered the same thing?

This question matters more than the syntax. It decides whether we are modeling identity or value.

## Why C# type design matters now

For a long time, many C# codebases mostly had one default shape: a mutable `class` with properties.

Modern C# gives us more expressive tools: `record class`, `record struct`, `readonly record struct`, `init`, `required`, and pattern matching. Those tools are useful only if they express intent.

The point is not to use new syntax everywhere. The point is to make the model say what it means.

## Identity

Use a `class` when the object has an identity that survives changes to its data.

Typical examples:

- `Customer`
- `Order`
- `ShoppingCart`
- `Subscription`

Two customers can have the same name and still be different customers. Two orders can have the same total and still be different orders.

```csharp
var first = new Customer("Ava");
var second = new Customer("Ava");
```

For entities, same data does not necessarily mean same thing.

## Value

Use a value-oriented type when the data is the meaning.

Typical examples:

- `Money`
- `EmailAddress`
- `CustomerId`
- `ProductKey`
- `DateRange`

```csharp
var first = new EmailAddress("ava@example.com");
var second = new EmailAddress("ava@example.com");
```

For values, same data usually means same concept.

## The first mental model

```text
class                  → object with identity
record class           → reference type with value equality
readonly record struct → small stable value signal
```

A class says: this thing has a life of its own.

A record says: the data is part of what the thing means.

A readonly record struct says: this is a small value that should not move under your feet.

## Self-check

- Which types in your current codebase are entities?
- Which primitive values represent domain concepts?
- Which bugs could happen because two different concepts share the same primitive type?
