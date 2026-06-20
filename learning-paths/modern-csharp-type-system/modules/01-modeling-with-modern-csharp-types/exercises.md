---
layout: module
title: Capstone exercises
description: Refactor one small subscription pricing model step by step.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/09-decision-guide/
previous_label: Decision guide
---

## Capstone — Subscription pricing model

The exercises now follow one progression. You start with weak primitives, then improve the model one decision at a time.

The goal is not to write a complete application. The goal is to practice choosing type shapes deliberately.

## Starting point

```csharp
public sealed class Subscription
{
    public Guid CustomerId { get; set; }
    public Guid SubscriptionId { get; set; }
    public Guid PlanId { get; set; }

    public string Sku { get; set; } = "";
    public string Country { get; set; } = "";
    public decimal MonthlyPrice { get; set; }
    public string Currency { get; set; } = "EUR";

    public bool IsTrial { get; set; }
    public bool IsActive { get; set; }
    public bool IsCancelled { get; set; }
    public DateTime? TrialEndsAt { get; set; }
    public DateTime? CancelledAt { get; set; }
}
```

## Exercise 1 — Predict collection behavior

Create a product key as a normal class with `Sku` and `Country`. Use two equivalent instances in a `HashSet<T>` and as dictionary lookup keys.

<details>
<summary>Hint</summary>

Before running the code, predict whether the collection uses object identity or content equality.

</details>

<details>
<summary>Suggested direction</summary>

Compare three options: normal class, record class, and `readonly record struct`.

</details>

<details>
<summary>Reflection</summary>

Which type best communicates “this is a small stable catalog key”?

</details>

## Exercise 2 — Stabilize the catalog key

Replace `Sku` and `Country` on the subscription with a named product key.

<details>
<summary>Hint</summary>

The key is small, content-based, and likely to be used in dictionaries.

</details>

<details>
<summary>Suggested solution</summary>

```csharp
public readonly record struct ProductKey(string Sku, string Country);
```

</details>

<details>
<summary>Reflection</summary>

What bug would become easier to catch if the code used `ProductKey` everywhere instead of two strings?

</details>

## Exercise 3 — Introduce strongly typed IDs

Replace the three `Guid` properties with typed IDs.

<details>
<summary>Hint</summary>

Customer, subscription, and plan IDs all share the same primitive representation, but they are different concepts.

</details>

<details>
<summary>Suggested solution</summary>

```csharp
public readonly record struct CustomerId(Guid Value);
public readonly record struct SubscriptionId(Guid Value);
public readonly record struct PlanId(Guid Value);
```

</details>

<details>
<summary>Reflection</summary>

Which method calls can the compiler now protect? Where will mapping code be needed?

</details>

## Exercise 4 — Add Money

Replace `MonthlyPrice` and `Currency` with a `Money` value object.

<details>
<summary>Hint</summary>

The rule to protect is not only “there is an amount”. The rule is “amount and currency belong together”.

</details>

<details>
<summary>Suggested direction</summary>

Start with:

```csharp
public readonly record struct Money(decimal Amount, string Currency);
```

Then add validation or operations only when the exercise needs them.

</details>

<details>
<summary>Reflection</summary>

What operation should fail if two `Money` values have different currencies?

</details>

## Exercise 5 — Replace flags with states

Replace the boolean and nullable state fields with explicit subscription states.

<details>
<summary>Hint</summary>

Each state should carry only the data that makes sense for that state.

</details>

<details>
<summary>Suggested solution</summary>

```csharp
public abstract record SubscriptionState;
public sealed record Trial(DateTime EndsAt) : SubscriptionState;
public sealed record Active : SubscriptionState;
public sealed record Cancelled(DateTime CancelledAt) : SubscriptionState;
```

</details>

<details>
<summary>Reflection</summary>

Which invalid combinations disappeared? Which transition rules still need explicit validation?

</details>

## Exercise 6 — Choose the contract

Decide how the improved model should be serialized for an API.

<details>
<summary>Hint</summary>

Do not assume the internal type hierarchy must be the public JSON shape.

</details>

<details>
<summary>Suggested direction</summary>

Compare a flat DTO with a discriminated state shape. Choose based on client needs, versioning, and stability.

</details>

<details>
<summary>Reflection</summary>

Which shape is easiest for clients to consume? Which shape best preserves the domain model? Where is the compromise?

</details>
