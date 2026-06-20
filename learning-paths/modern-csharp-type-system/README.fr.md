# Système de types C# moderne

Un parcours pratique pour développeurs backend qui veulent utiliser le système de types C# de façon plus intentionnelle.

Le parcours part de deux présentations en français et les transforme progressivement en learning lab réutilisable : modélisation métier, sémantique de valeur, strongly typed IDs, états modélisés par les types, et types mémoire en .NET.

## Supports actuels

| Élément | Langue | Description |
| --- | --- | --- |
| [Talk 1 — Système de types C# moderne](talks/01-modern-csharp-type-system-fr/) | Français | Modélisation applicative avec les types modernes de C#. |
| [Talk 2 — Types mémoire en .NET](talks/02-dotnet-memory-types-fr/) | Français | `Span<T>`, `Memory<T>`, `ref struct`, `stackalloc`, pooling et benchmarks. |

## Lancer les samples

```bash
dotnet run --project src/DomainTypes.Samples -- --all
dotnet run --project src/MemoryTypes.Samples -- --all
```

## Lancer les benchmarks

```bash
dotnet run -c Release --project src/DomainTypes.Benchmarks -- --filter *DictionaryKey*
dotnet run -c Release --project src/MemoryTypes.Benchmarks
```
