# Module 01 — Modeling with modern C# types

A practical module for backend developers who want to use C# types to express intent: identity, value, equality, stable keys, small domain concepts, and valid state transitions.

This README is the GitHub-facing overview. The web version starts at [`index.md`](index.md) and follows the narrative of the original presentation with short lessons.

## Audience

This module is for developers who already write C# but want clearer rules for choosing between `class`, `record class`, `struct`, `record struct`, and `readonly record struct` in application and domain code.

You do not need advanced performance knowledge. The focus is modeling, correctness, and API clarity.

## Run the samples

From the repository root:

```bash
dotnet build learning-paths/modern-csharp-type-system/src/DomainTypes.Samples
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --all
```

Run one demo at a time:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo collections
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo ids
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo state-modeling
```

## Lessons

1. [Identity vs value](01-identity-vs-value.md)
2. [Records and generated equality](02-records-and-equality.md)
3. [Stable dictionary keys](03-stable-dictionary-keys.md)
4. [Strongly typed IDs](04-strongly-typed-ids.md)
5. [Value objects](05-value-objects.md)
6. [Mutability traps](06-record-structs.md)
7. [Type-driven state modeling](07-type-driven-state-modeling.md)
8. [Serialization contracts](08-serialization.md)
9. [Decision guide](09-decision-guide.md)
10. [Capstone exercises](exercises.md)

## Core idea

A good type makes the valid path natural and the invalid path harder to write.
