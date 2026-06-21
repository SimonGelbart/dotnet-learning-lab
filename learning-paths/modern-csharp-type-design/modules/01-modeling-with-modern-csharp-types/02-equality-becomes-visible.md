# 02 - Equality becomes visible

## Mission

Predict what `HashSet<T>` and `Dictionary<TKey, TValue>` will do when equality comes from identity or from data.

Equality can feel abstract until a collection asks a concrete question:

> Have I already seen this key?

## The problem

A price catalog needs one price per product and country.

```text
SKU + Country
```

Business rule:

> The same product key should not appear twice.

Start with a classic class:

```csharp
public sealed class ProductKeyClass
{
    public ProductKeyClass(string sku, string country)
    {
        Sku = sku;
        Country = country;
    }

    public string Sku { get; }
    public string Country { get; }
}
```

## Prediction 1: `HashSet` with a class

What prints?

```csharp
var a = new ProductKeyClass("ABC", "FR");
var b = new ProductKeyClass("ABC", "FR");

var set = new HashSet<ProductKeyClass> { a, b };

Console.WriteLine(set.Count);
```

Think before reading on.

Expected result:

```text
2
```

The two objects contain the same values, but a normal `class` uses reference equality by default. The set sees two different object references.

## Prediction 2: `HashSet` with a record

Now change the type shape.

```csharp
public sealed record ProductKeyRecord(string Sku, string Country);

var a = new ProductKeyRecord("ABC", "FR");
var b = new ProductKeyRecord("ABC", "FR");

var set = new HashSet<ProductKeyRecord> { a, b };

Console.WriteLine(set.Count);
```

Expected result:

```text
1
```

The record generates equality by data. The set sees two equivalent product keys.

## Prediction 3: `Dictionary` lookup with a class

What prints?

```csharp
var prices = new Dictionary<ProductKeyClass, decimal>();

prices[new ProductKeyClass("ABC", "FR")] = 19.99m;

Console.WriteLine(
    prices.ContainsKey(new ProductKeyClass("ABC", "FR"))
);
```

Expected result:

```text
False
```

The dictionary looks for a key that is equal to the lookup key. With the class above, that means the same reference, not just the same values.

## Alternative: keep the class, provide equality

A class can still work if you define equality explicitly.

For example, pass a comparer:

```csharp
var prices = new Dictionary<ProductKeyClass, decimal>(
    new ProductKeyClassComparer());
```

Or override `Equals(...)` and `GetHashCode()` on the class.

The important part is not that records are always better. The important part is that equality must live somewhere.

## What collections use

`HashSet<T>` and `Dictionary<TKey, TValue>` rely on:

```text
Equals(...) + GetHashCode()
```

Records are convenient because they generate these members consistently for data-oriented types.

## Check yourself

When would you not use a record as the key?

One answer: when the key has identity, lifecycle, or mutability that makes value equality misleading.

## Rule of thumb

If the business key is the data, make equality by data explicit.

Next: [Stable keys and shallow immutability](03-stable-keys-and-immutability.md).
