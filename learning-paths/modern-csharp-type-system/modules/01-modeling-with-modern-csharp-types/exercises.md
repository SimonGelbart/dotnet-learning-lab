---
layout: module
title: Exercises
description: Practice the module ideas with hints, suggested solutions, and reflection questions.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/08-serialization/
previous_label: Serialization notes
---

## Exercise 1 — Replace primitive IDs

Take a service method that accepts multiple `Guid` parameters. Replace them with strongly typed IDs.

```csharp
void Transfer(Guid sourceAccountId, Guid destinationAccountId, Guid initiatedByUserId)
```

<details>
<summary>Hint</summary>

Create one small type for each domain concept, even if they all wrap `Guid`.

</details>

<details>
<summary>Suggested solution</summary>

```csharp
public readonly record struct AccountId(Guid Value);
public readonly record struct UserId(Guid Value);

void Transfer(AccountId source, AccountId destination, UserId initiatedBy) { }
```

</details>

<details>
<summary>Reflection</summary>

Which mistakes does the compiler now prevent? What serialization or mapping code would you need in a real application?

</details>

## Exercise 2 — Fix a dictionary key

Create a dictionary keyed by a mutable class, mutate the key after insertion, and observe the lookup failure. Then refactor the key to a stable value.

<details>
<summary>Hint</summary>

Hash-based collections use equality and hash code behavior to place keys. If the key changes after insertion, lookup may use the wrong hash bucket.

</details>

<details>
<summary>Suggested solution</summary>

```csharp
public readonly record struct ProductKey(string Sku, string Country);

var key = new ProductKey("ABC", "FR");
var prices = new Dictionary<ProductKey, decimal>();
prices[key] = 19.99m;
```

</details>

<details>
<summary>Reflection</summary>

Which part of the original key was unstable? Should this key be a class, record class, or readonly record struct?

</details>

## Exercise 3 — Model a state machine

Model an onboarding process with explicit states: `Invited`, `Registered`, and `Rejected`. Avoid booleans and nullable fields on one big object.

<details>
<summary>Hint</summary>

Start with an abstract base state and one concrete record per valid state.

</details>

<details>
<summary>Suggested solution</summary>

```csharp
public abstract record OnboardingState;
public sealed record Invited(string Email, DateTime InvitedAt) : OnboardingState;
public sealed record Registered(UserId UserId, DateTime RegisteredAt) : OnboardingState;
public sealed record Rejected(string Reason, DateTime RejectedAt) : OnboardingState;
```

</details>

<details>
<summary>Reflection</summary>

Which invalid combinations disappeared? Which business rules still need explicit validation? How would you serialize this model?

</details>
