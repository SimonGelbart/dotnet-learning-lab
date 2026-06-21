# 03 - Stable keys and shallow immutability

## Mission

Avoid collection bugs that compile cleanly.

Once a value participates in equality and hashing, stability matters.

## The problem

A dictionary places a key into an internal bucket based on its hash code. If the data used by `GetHashCode()` changes after insertion, the dictionary can no longer reliably find it.

Here is the bug:

```csharp
var key = new MutableProductKey { Sku = "ABC", Country = "FR" };
var prices = new Dictionary<MutableProductKey, decimal>();

prices[key] = 19.99m;
key.Country = "US";

Console.WriteLine(prices.ContainsKey(key));
```

The object is still the same reference, but the value used to find it has changed.

## Better model

Use a stable key.

```csharp
public readonly record struct ProductKey(string Sku, string Country);
```

Now the key expresses what the collection needs:

- equality by data;
- stable values after creation;
- no separate comparer for the common case.

## The shallow immutability trap

`readonly` does not mean deep immutability.

```csharp
public readonly record struct TeamSnapshot(List<string> Members);

var snapshot = new TeamSnapshot([]);
snapshot.Members.Add("Alice"); // possible
```

The positional property cannot be reassigned, but the list object can still be mutated.

A safer public shape might be:

```csharp
public readonly record struct TeamSnapshot(IReadOnlyList<string> Members);
```

Even then, if you need real immutability, consider immutable collections or defensive copies.

## Why this matters

Modern syntax can make a type look safer than it really is.

Ask two questions:

1. Can callers replace the value?
2. Can callers mutate something inside the value?

Those are different questions.

## Check yourself

Which of these is safest as a dictionary key?

```csharp
public sealed class ProductKey(string Sku, string Country);
public record struct ProductKey(string Sku, string Country);
public readonly record struct ProductKey(string Sku, string Country);
public readonly record struct ProductKey(List<string> Parts);
```

Best answer: the third option is the cleanest default for a small stable key. The fourth still exposes mutable referenced data.

## Rule of thumb

A dictionary key must not move after you put it in the dictionary.

Next: [Small business values](04-small-business-values.md).
