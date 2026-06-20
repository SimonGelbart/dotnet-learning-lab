---
layout: module
title: Module 01 — Modeling with modern C# types
description: Use C# types to express identity, value, equality, stable keys, small domain concepts, and valid state transitions.
permalink: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/01-identity-vs-value/
next_label: Start lesson 01
---

## Audience

This module is for intermediate .NET developers who already write C# but want clearer rules for choosing between `class`, `record class`, `struct`, `record struct`, and `readonly record struct` in application and domain code.

The focus is modeling, correctness, and API clarity. Performance appears only where it affects type choices; benchmark claims are kept out until measured.

## Learning objectives

By the end of this module, you should be able to:

- Explain the difference between identity and value.
- Predict how generated equality affects `HashSet<T>` and `Dictionary<TKey, TValue>`.
- Identify why mutable dictionary keys are dangerous.
- Replace ambiguous primitive IDs with strongly typed IDs.
- Use small value objects to encode domain constraints.
- Model state with explicit types instead of boolean flags and nullable fields.
- Make deliberate serialization choices when internal models become richer.

## Run the samples

From the repository root:

```bash
dotnet build learning-paths/modern-csharp-type-system/src/DomainTypes.Samples
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --all
```

## Lessons

| Lesson | Focus |
| --- | --- |
| [01 — Identity vs value](01-identity-vs-value/) | Decide whether same data means same concept. |
| [02 — Records and generated equality](02-records-and-equality/) | Understand how records change equality and collections. |
| [03 — Stable dictionary keys](03-stable-dictionary-keys/) | See why keys must not change after insertion. |
| [04 — Strongly typed IDs](04-strongly-typed-ids/) | Prevent ID mix-ups at compile time. |
| [05 — Value objects](05-value-objects/) | Wrap domain concepts that need invariants. |
| [06 — record struct vs readonly record struct](06-record-structs/) | Avoid accidental mutability in small values. |
| [07 — Type-driven state modeling](07-type-driven-state-modeling/) | Replace invalid flag combinations with explicit states. |
| [08 — Serialization notes](08-serialization/) | Keep API and persistence contracts deliberate. |
| [Exercises](exercises/) | Practice with hints, suggested solutions, and reflections. |

## Core idea

A good type makes the valid path natural and the invalid path harder to write.
