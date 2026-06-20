---
layout: module
title: 08 — Serialization notes
description: Internal type models still need deliberate API and persistence contracts.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo serialization
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/07-type-driven-state-modeling/
previous_label: Type-driven state modeling
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/exercises/
next_label: Exercises
---

## Goal

Avoid exposing accidental internal model details through serialization.

## Why this matters

Type-driven state models are useful inside the application, but public APIs and persistence models need stable contracts.

If your serialized shape depends directly on internal type names, later refactors can become breaking changes.

## Questions to decide deliberately

- What discriminator name do you use?
- Is the serialized shape stable?
- Can older clients read newer states?
- Are you exposing internal type names accidentally?
- Should persistence use the same shape as the public API?

## Practical rule

Use rich internal types to make the application code safer, but define the serialized contract explicitly.

## Self-check

- What serialization decisions appear when you model states with a record hierarchy?
- Which parts of your internal model are safe to expose?
- Which parts should stay private to the application?
