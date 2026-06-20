---
layout: module
title: 01 — Identity vs value
description: Start with the most important modeling question: does this concept have identity, or is it defined by its data?
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo copying
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
previous_label: Module overview
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/02-records-and-equality/
next_label: Records and equality
---

## Goal

Decide whether two instances with the same data should be considered the same thing.

That question drives many C# type choices.

## Why this matters

A `Customer`, an `Order`, or a `Subscription` usually has identity beyond its current data. Two customers can have the same name and still be different customers.

A `Money`, `EmailAddress`, `CustomerId`, or `DateRange` is usually a value. If the data is the same, the concept is the same.

## Problem example

```csharp
var first = new Customer("Ava");
var second = new Customer("Ava");
```

Should those be equal? Usually no. They are two entities that happen to share data.

Now compare:

```csharp
var first = new EmailAddress("ava@example.com");
var second = new EmailAddress("ava@example.com");
```

Here, equality by content probably matches the domain concept.

## Better model

Use a `class` when object identity matters. Use a record or small immutable value when content equality is part of the meaning.

A useful rule:

> A class says: this thing has identity. A record says: the data is part of what the thing means.

## Self-check

- When should two objects with the same data still be different objects?
- Which concepts in your current codebase are values disguised as primitives?
- Which concepts are entities that should not become records just because records are convenient?
