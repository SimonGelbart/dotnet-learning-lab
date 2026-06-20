# Modern C# type system

A practical learning path for backend developers who want to use the C# type system deliberately.

The path starts from two French talks and turns them into a reusable learning lab covering domain modeling, value semantics, strongly typed IDs, type-driven state modeling, and memory-oriented .NET types.

## What you will learn

- When to model something as an identity versus a value.
- How `class`, `record class`, `struct`, `record struct`, and `readonly record struct` differ in practice.
- How generated equality changes collection behavior and API expectations.
- How strongly typed IDs and value objects reduce primitive obsession.
- How to model valid states with explicit types instead of flags and nullable data.
- When `Span<T>`, `ReadOnlySpan<T>`, `Memory<T>`, and `ReadOnlyMemory<T>` are useful.
- Why allocation-aware code should start from measurement, not from premature optimization.

## Current material

| Item | Language | Description |
| --- | --- | --- |
| [Talk 1 — Modern C# type system](talks/01-modern-csharp-type-system-fr/) | French | Domain modeling with modern C# types. |
| [Talk 2 — .NET memory types](talks/02-dotnet-memory-types-fr/) | French | `Span<T>`, `Memory<T>`, `ref struct`, `stackalloc`, pooling, and benchmarks. |

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

## Planned modules

1. Choosing between identity and value.
2. Records, structs, and generated equality.
3. Strongly typed IDs and value objects.
4. Type-driven state modeling.
5. Memory-oriented types in .NET.
6. `Span<T>`, `Memory<T>`, and lifetime boundaries.
7. Allocation-aware design and benchmarks.
