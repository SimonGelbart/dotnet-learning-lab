# Talk 1 — Système de types C# moderne

Durée cible : **45 minutes**.

## Objectif

Montrer que les features modernes de C# — `record`, `record struct`, `readonly record struct`, `init`, `required`, pattern matching — ne servent pas seulement à écrire moins de code. Elles servent à mieux exprimer l’intention : identité, valeur, égalité, stabilité et états métier valides.

## Support

- `speaker-guide.md` : guide présentateur.
- `presentation/README.md` : note sur le support de présentation original.

## Démos

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --all
```

Démos disponibles :

- `copying`
- `collections`
- `mutable-key`
- `ids`
- `money`
- `record-struct`
- `state-modeling`
- `serialization`

## Benchmark optionnel

Le benchmark est conservé dans le projet, mais retiré du deck principal.

```bash
dotnet run -c Release --project learning-paths/modern-csharp-type-system/src/DomainTypes.Benchmarks -- --filter *DictionaryKey*
```

À utiliser seulement si quelqu’un pose une question performance sur les clés de dictionnaire.


## Notes V9 / V9.2

Le deck principal privilégie les résultats révélables plutôt que les blocs de commandes. Les samples restent disponibles dans `learning-paths/modern-csharp-type-system/src/DomainTypes.Samples` et via les tâches VS Code.


## Notes V9.2

La version 9.1 est une itération de polish : corrections d’exemples, timing réaliste à 45 minutes, JSON plus lisible, et wording plus précis sur la modélisation d’états.

## Note V9.4

Cette itération ajoute une touche plus légère dans les titres, simplifie le rendu visuel avec une palette flat design, et garde le contenu inchangé côté progression pédagogique.
