# Talk 2 — Types mémoire en .NET

Durée cible : **45 minutes**.

## Objectif

Comprendre quand et pourquoi utiliser `Span<T>`, `ReadOnlySpan<T>`, `Memory<T>`, `ReadOnlyMemory<T>`, `ref struct`, `stackalloc` et `MemoryPool<T>`.

## Démos

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/MemoryTypes.Samples -- --all
```

## Benchmarks

```bash
dotnet run -c Release --project learning-paths/modern-csharp-type-system/src/MemoryTypes.Benchmarks
```

Interprétation prudente : `string.Split` matérialise un tableau et des strings ; un parser Span retourne des vues. Les résultats illustrent allocations et throughput, pas une règle universelle.


## Support

- `speaker-guide.md` : guide présentateur.
- `presentation/README.md` : note sur le support de présentation original.
