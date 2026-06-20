# Speaker guide — Talk 2

Durée cible : **45 minutes**.

## Rythme recommandé

| Temps | Sujet |
|---:|---|
| 5 min | Pourquoi parler de mémoire ? |
| 7 min | Owner vs View |
| 9 min | string.Split vs Span |
| 8 min | ref struct et restrictions |
| 8 min | Memory<T> et async |
| 5 min | stackalloc / MemoryPool |
| 3 min | benchmark et decision tree |

## Points à marteler

- `Span<T>` est une vue locale et synchrone.
- `Memory<T>` peut être stocké et traverser des APIs async.
- Les restrictions de `ref struct` protègent la lifetime.
- `stackalloc` est utile pour petits buffers temporaires bornés.
- On utilise ces types après mesure, pas par réflexe.
