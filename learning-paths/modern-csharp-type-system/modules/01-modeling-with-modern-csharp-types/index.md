---
layout: module
title: Module 01 — Modeling with modern C# types
description: A narrative path for using C# types to express identity, value, equality, stable keys, business concepts, and valid states.
permalink: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/01-identity-vs-value/
next_label: Start lesson 01
---

## What this module is really about

This module is not a tour of syntax.

Modern C# gives us more choices than “class or struct”. That is useful, but it also means the type we choose sends a message to the next developer reading the code.

```text
class                  → this thing has identity
record class           → this thing is compared by its data
readonly record struct → this is a small stable value
```

The goal is to use those signals deliberately.

## The story arc

We start with one modeling question:

> If two instances have the same data, should they be considered the same thing?

From there, the module follows the consequences:

1. Identity and value are different ideas.
2. Records make equality visible.
3. Collections turn equality mistakes into concrete bugs.
4. Stable keys protect lookups.
5. Strongly typed IDs protect method calls.
6. Value objects protect business meaning.
7. Mutability can break the model even when the syntax looks modern.
8. Explicit state types remove invalid combinations.
9. Serialization is a contract, not a side effect.
10. A decision guide helps us choose under pressure.

## Audience

This module is for intermediate .NET developers who already write C# and want clearer rules for application and backend modeling.

You do not need advanced performance knowledge. The focus is correctness, API clarity, and practical trade-offs.

## Run the samples

From the repository root:

```bash
dotnet build learning-paths/modern-csharp-type-system/src/DomainTypes.Samples
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --all
```

## Lessons

| Lesson | Focus |
| --- | --- |
| [01 — Identity vs value](01-identity-vs-value/) | Start from the modeling question that drives the rest. |
| [02 — Records and generated equality](02-records-and-equality/) | See why records are about equality, not magic. |
| [03 — Stable dictionary keys](03-stable-dictionary-keys/) | Follow equality into `HashSet<T>` and `Dictionary<TKey,TValue>`. |
| [04 — Strongly typed IDs](04-strongly-typed-ids/) | Stop GUIDs from disguising themselves as each other. |
| [05 — Value objects](05-value-objects/) | Use `Money` to show how values protect business meaning. |
| [06 — Mutability traps](06-record-structs/) | Connect shallow immutability, mutable keys, and `record struct`. |
| [07 — Type-driven state modeling](07-type-driven-state-modeling/) | Move from flags to enum to dedicated state records. |
| [08 — Serialization contracts](08-serialization/) | Choose the external shape deliberately. |
| [09 — Decision guide](09-decision-guide/) | Keep practical team rules close to the keyboard. |
| [Capstone exercises](exercises/) | Refactor one small domain model step by step. |

## Core idea

A good type makes the valid path natural and the invalid path harder to write.
