# Modern C# Type Design Outline

Course promise:

> Design backend models that make invalid code harder to write.

Target duration: **45-60 minutes**.

## 0. Orientation - 5 min

Mission: understand why type choice matters.

Introduce the core idea:

> A good type makes the valid path natural and the invalid path harder to write.

Show the course map:

1. identity and value;
2. equality and collections;
3. stable keys and immutability;
4. small business values;
5. valid states;
6. decision guide.

## 1. Identity or value? - 8 min

Mission: decide whether a model should behave like an entity or like data.

Use examples:

- `Customer` as identity and lifecycle;
- `UserDto` as a data contract;
- `OrderId` as a small stable value;
- `Money` as a business value.

Key distinction:

- `class` for identity, lifecycle, shared state, and behavior;
- `record class` for data-oriented reference types with value equality;
- `readonly record struct` for small stable values.

Checkpoint: classify five names as likely identity, value, DTO, or state.

## 2. Equality becomes visible - 10 min

Mission: predict what `HashSet<T>` and `Dictionary<TKey, TValue>` will do.

Use the product price catalog example:

```text
SKU + Country
```

Ask prediction questions before revealing results:

- What does `HashSet<ProductKeyClass>` count?
- What does `HashSet<ProductKeyRecord>` count?
- Why does `Dictionary<ProductKeyClass, decimal>` fail lookup with a new equivalent instance?

Teaching rule:

`HashSet<T>` and `Dictionary<TKey, TValue>` rely on `Equals(...)` and `GetHashCode()`.

## 3. Stable keys and shallow immutability - 8 min

Mission: avoid a collection bug that compiles cleanly.

Show the mutable key problem:

```csharp
prices[key] = 19.99m;
key.Country = "US";
prices.ContainsKey(key);
```

Then teach shallow immutability:

```csharp
public readonly record struct TeamSnapshot(List<string> Members);
```

Key distinction:

- `readonly` protects assignment;
- it does not make referenced objects deeply immutable.

Checkpoint: decide which models are safe dictionary keys.

## 4. Small business values - 10 min

Mission: replace fragile conventions with types.

Use strongly typed IDs:

```csharp
public readonly record struct CustomerId(Guid Value);
public readonly record struct OrderId(Guid Value);
```

Then use `Money` to show a local business rule:

- `10 EUR` and `10 USD` are not interchangeable;
- adding different currencies should fail deliberately.

Warning:

`record struct` is mutable by default. Prefer `readonly record struct` for small stable values unless mutation is intentional.

## 5. Modeling valid states - 14 min

Mission: make impossible subscription states harder to represent.

Progression:

1. bool flags and nullable dates;
2. `enum` status;
3. dedicated record states;
4. pattern matching;
5. JSON trade-off.

The learner should see that:

- bool flags allow invalid combinations;
- an enum improves exclusivity;
- state-specific data still needs a better home;
- dedicated state types attach the right data to the right state;
- serialization needs an explicit external contract.

## 6. Decision guide - 5 min

Mission: leave with a practical rule of thumb.

Use the [decision guide](decision-guide.md) as the durable takeaway.

Final reminder:

Modern C# type design is not about using new syntax everywhere. It is about making intent visible and invalid usage harder.
