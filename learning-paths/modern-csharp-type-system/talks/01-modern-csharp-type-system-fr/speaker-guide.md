# Speaker guide — Talk 1

Durée cible : **45 minutes**.

## Ligne directrice

> Le système de types moderne de C# sert à exprimer l’intention du code applicatif.

Ne pas présenter les records comme une syntaxe plus courte. Les présenter comme un outil pour clarifier : identité, valeur, égalité, stabilité et états métier valides.

## Rythme recommandé

| Temps | Sujet |
|---:|---|
| 5 min | Introduction moderne + référence vs valeur |
| 6 min | class / record class / readonly record struct |
| 3 min | Ce que les records génèrent |
| 11 min | HashSet / Dictionary / IEqualityComparer / clé mutable |
| 5 min | strongly typed IDs, Money, record struct mutable |
| 11 min | Subscription : bools → enum → record states → GetStatusMessage |
| 2 min | sérialisation JSON polymorphique |
| 2 min | takeaways + decision tree |

## Points à marteler

- Ces features sont modernes : elles n’étaient pas disponibles dans beaucoup de bases C# / .NET Framework historiques.
- Un `record` ne change pas `Dictionary` ; il fournit `Equals()` / `GetHashCode()`.
- Une clé de dictionnaire doit être stable après insertion.
- `readonly record struct` est excellent pour les petites valeurs, mais l’immutabilité reste shallow.
- `enum` est une amélioration réelle par rapport aux booléens, mais il ne lie pas les données spécifiques à chaque état.
- La sérialisation du modèle record state est polymorphique : il faut un discriminateur stable, par exemple `kind`.

## Interactions

Les blocs de commandes ont été retirés des slides. Les résultats sont révélés directement avec **Afficher résultat attendu**. Les commandes restent dans le README et les tâches VS Code.


## Notes V9.1

- Le rythme recommandé somme maintenant à 45 minutes.
- La slide JSON utilise des cartes verticales plutôt qu’un tableau compact.
- La comparaison finale parle de données liées au bon état, pas de cohérence métier totale.


## Note V9.3

La slide “Référence ou valeur ?” est volontairement placée après les premières slides de types : elle sert de modèle mental avant d’attaquer l’égalité et les collections.

## Note V9.4

Les titres sont volontairement plus mémorables et légèrement humoristiques. Garder le ton oral, mais éviter de surjouer : l’humour sert de repère, pas de gag.
