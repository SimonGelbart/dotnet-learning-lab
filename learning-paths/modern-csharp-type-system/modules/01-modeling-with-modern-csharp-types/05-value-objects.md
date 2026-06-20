---
layout: module
title: 05 — Value objects
description: Use small immutable values to make domain concepts explicit.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo money
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/04-strongly-typed-ids/
previous_label: Strongly typed IDs
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/06-record-structs/
next_label: record struct vs readonly record struct
---

## Goal

Recognize when a primitive value is not enough to represent a concept safely.

## Why this matters

A value object is a small domain concept that is equal by value and should usually be immutable.

`Money` is a useful example because `decimal amount` alone loses important meaning.

## Problem example

```csharp
decimal subtotal = 10m;
decimal shipping = 5m;
decimal total = subtotal + shipping;
```

This compiles, but it does not say anything about currency. It also does not stop someone from adding EUR to USD.

## Better model

A `Money` value can carry both amount and currency, and it can decide what operations are valid.

A value object should usually protect one invariant or make one concept explicit. Do not create value objects only to make the code look domain-driven.

## Self-check

- What invariant does the value object protect?
- Is equality by content correct for this concept?
- Are you adding a type because it prevents mistakes, or only because it looks cleaner?
