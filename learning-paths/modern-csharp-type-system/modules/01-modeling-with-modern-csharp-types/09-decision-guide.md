---
layout: module
title: 09 — Decision guide
description: Keep practical type-design rules close to the keyboard.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/08-serialization/
previous_label: Serialization contracts
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/exercises/
next_label: Capstone exercises
---

## Goal

Turn the module into a practical decision guide.

## Start with the domain question

Do not start with the keyword. Start with the meaning.

> What kind of concept is this?

## Rules to keep at the keyboard

| Situation | Prefer | Why |
| --- | --- | --- |
| Long-lived domain entity with identity | `class` | Same data does not necessarily mean same object. |
| Immutable content-based data shape | `record class` | Equality by content is part of the concept. |
| Small stable value or key | `readonly record struct` | Clear value semantics without accidental mutation. |
| Dictionary key | Stable immutable type with explicit equality | Hash-based lookup depends on stable equality. |
| Primitive ID crossing boundaries | Strongly typed ID | The compiler can prevent concept mix-ups. |
| Small business concept with invariants | Value object | The type protects meaning and rules. |
| State with different data per case | Dedicated state records | Each state owns only the data that is valid. |
| Public API or persistence shape | Explicit contract | Internal type design should not leak accidentally. |

## Decision tree

Ask these questions in order:

1. Does this concept have identity over time?
   - Yes: start with `class`.
   - No: continue.
2. Is equality by content the natural behavior?
   - Yes: consider a record or value object.
   - No: be careful before using a record.
3. Is it small, immutable, and often used as a key or ID?
   - Yes: consider `readonly record struct`.
4. Does the primitive representation hide domain meaning?
   - Yes: introduce a named type.
5. Can the current shape represent impossible states?
   - Yes: consider explicit state types.
6. Will this cross an API, database, or message boundary?
   - Yes: design the serialized contract explicitly.

## Final warning

Types reduce mistakes. They do not replace business rules, tests, or judgment.

The goal is not to make every value a type. The goal is to make important mistakes harder to write.
