# Modern C# Type Design

A practical learning path for intermediate .NET developers who want to use C# types deliberately.

The path shows how records, value objects, strongly typed IDs, stable dictionary keys, and state models can make backend code cleaner and harder to misuse.

> Transition note: this folder contains the current working material, split lessons, runnable samples, benchmarks, and archived talks. The future public course shape is being defined under [`../modern-csharp-type-design/`](../modern-csharp-type-design/).

## What you will learn

- When to model something as an identity versus a value.
- How `class`, `record class`, `struct`, `record struct`, and `readonly record struct` differ in practice.
- How generated equality changes collection behavior and API expectations.
- Why dictionary keys must be stable after insertion.
- How strongly typed IDs and value objects reduce primitive obsession.
- How to model valid states with explicit types instead of flags and nullable data.
- Why serialization needs an explicit contract when internal models become richer.

## Modules

| Module | Status | Focus |
| --- | --- | --- |
| [01 — Modeling with modern C# types](modules/01-modeling-with-modern-csharp-types/) | Draft | Identity vs value, generated equality, stable keys, strongly typed IDs, value objects, and type-driven state modeling. |

## Archived material

| Item | Language | Description |
| --- | --- | --- |
| [Talk 1 — Modern C# type system](talks/01-modern-csharp-type-system-fr/) | French | Original source material for Module 01. |
| [Talk 2 — .NET memory types](talks/02-dotnet-memory-types-fr/) | French | Original source material for a future memory-oriented module. |

## Run samples

```bash
dotnet run --project src/DomainTypes.Samples -- --all
dotnet run --project src/MemoryTypes.Samples -- --all
```

## Run benchmarks

```bash
dotnet run -c Release --project src/DomainTypes.Benchmarks -- --filter *DictionaryKey*
dotnet run -c Release --project src/MemoryTypes.Benchmarks
```
