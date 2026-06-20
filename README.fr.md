# dotnet-learning-lab

Learning paths, talks, exercices, samples et benchmarks autour du développement backend moderne en .NET.

Ce dépôt démarre avec un parcours pratique sur le système de types C# moderne. Le contenu initial vient de deux présentations en français ; le dépôt les conserve tout en les organisant comme un laboratoire d’apprentissage réutilisable.

## Parcours disponibles

| Parcours | Statut | Focus |
| --- | --- | --- |
| [Système de types C# moderne](learning-paths/modern-csharp-type-system/) | En cours | Records, sémantique de valeur, strongly typed IDs, modélisation d’états par les types, `Span<T>`, `Memory<T>` et conception attentive aux allocations. |

## Démarrage rapide

Lancer tous les samples :

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --all
dotnet run --project learning-paths/modern-csharp-type-system/src/MemoryTypes.Samples -- --all
```

Valider le setup local :

```bash
./tools/validate-before-talk.sh
```

Générer les liens locaux VS Code pour les présentations HTML :

```bash
./tools/setup-local-links.sh
```
