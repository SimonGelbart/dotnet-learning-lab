# Module 01 — Modéliser avec les types C# modernes

Module pratique pour développeurs backend qui veulent utiliser les types C# pour exprimer l’intention : identité, valeur, égalité, clés stables, petits concepts métier et états valides.

Ce module adapte le premier talk français, **Système de types C# moderne**, au format learning path. Le talk reste le support de présentation ; ce module sert de version asynchrone avec objectifs, samples, exercices et questions de vérification.

## Objectifs

À la fin du module, vous devriez pouvoir :

- Expliquer la différence entre identité et valeur.
- Choisir entre `class`, `record class`, `struct`, `record struct` et `readonly record struct` dans des cas backend courants.
- Anticiper l’impact de l’égalité générée sur `HashSet<T>` et `Dictionary<TKey, TValue>`.
- Expliquer pourquoi une clé mutable est dangereuse dans un dictionnaire.
- Remplacer des IDs primitifs ambigus par des strongly typed IDs.
- Utiliser de petits value objects pour rendre un concept métier explicite.
- Modéliser un état avec des types explicites plutôt qu’avec des booléens et des champs nullables.

## Idée centrale

Un bon type rend le chemin valide naturel et le chemin invalide plus difficile à écrire.

Les features modernes de C# ne sont pas seulement du sucre syntaxique. Utilisées intentionnellement, elles aident à communiquer ce qu’un concept représente :

- une entité avec identité ;
- une valeur égale par contenu ;
- une clé petite et stable ;
- un état qui porte uniquement les données valides pour cet état.

## Démarrer

Depuis la racine du dépôt :

```bash
dotnet build learning-paths/modern-csharp-type-system/src/DomainTypes.Samples
```

Lancer toutes les démos du module :

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --all
```

Lancer une démo spécifique :

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo collections
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo ids
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo state-modeling
```

## Progression

1. Identité vs valeur.
2. Records et égalité générée.
3. `HashSet<T>`, `Dictionary<TKey, TValue>` et clés stables.
4. Strongly typed IDs.
5. Value objects.
6. `record struct` mutable vs `readonly record struct`.
7. Modélisation d’état avec des types explicites.
8. Sérialisation des hiérarchies de records.

## Exercices

### Exercice 1 — Remplacer des IDs primitifs

Prenez une méthode qui accepte plusieurs `Guid` et remplacez-les par des IDs typés.

Avant :

```csharp
void Transfer(Guid sourceAccountId, Guid destinationAccountId, Guid initiatedByUserId)
```

Après :

```csharp
void Transfer(AccountId source, AccountId destination, UserId initiatedBy)
```

Questions :

- Quelles erreurs le compilateur empêche maintenant ?
- Quel code de sérialisation ou de mapping faudrait-il dans une application réelle ?

### Exercice 2 — Corriger une clé mutable

Créez un dictionnaire avec une classe mutable comme clé, modifiez la clé après insertion, puis observez l’échec de lookup. Refactorez ensuite la clé en `readonly record struct`.

La démo `mutable-key` sert de point de départ.

### Exercice 3 — Modéliser un état

Modélisez un processus d’onboarding avec ces états :

- `Invited(email, invitedAt)`
- `Registered(userId, registeredAt)`
- `Rejected(reason, rejectedAt)`

Évitez un gros objet avec `IsRegistered`, `RegisteredAt?`, `RejectedAt?`, etc.

## Questions de vérification

- Quand deux objets avec les mêmes données doivent-ils rester deux objets différents ?
- Qu’est-ce qu’un record génère qui compte pour un dictionnaire ?
- Pourquoi une clé mutable est-elle dangereuse après insertion ?
- Quel problème les strongly typed IDs résolvent-ils ?
- Quel problème ne résolvent-ils pas ?
- Pourquoi `readonly record struct` est-il souvent préférable à `record struct` pour une petite valeur ?
- Quelles décisions de sérialisation apparaissent avec une hiérarchie de records ?

## À retenir

- Les types sont des outils de design, pas seulement des conteneurs de données.
- Les records sont utiles quand l’égalité par contenu fait partie du concept.
- Une clé de dictionnaire doit rester stable.
- Les strongly typed IDs réduisent les confusions accidentelles entre APIs.
- Des types spécifiques par état réduisent les formes d’objet invalides.

## Matériel lié

- Talk source : `talks/01-modern-csharp-type-system-fr/`
- Samples : `src/DomainTypes.Samples/`
- Benchmarks : `src/DomainTypes.Benchmarks/`
