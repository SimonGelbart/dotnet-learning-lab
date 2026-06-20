---
layout: module
title: 07 — Type-driven state modeling
description: Move from flags to enum to dedicated state records so invalid states become harder to represent.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo state-modeling
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/06-record-structs/
previous_label: Mutability traps
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/08-serialization/
next_label: Serialization contracts
---

## Goal

Represent business states without allowing impossible combinations.

## Version 1 — booleans and nullables

A subscription might start like this:

```csharp
public sealed class Subscription
{
    public bool IsTrial { get; set; }
    public bool IsActive { get; set; }
    public bool IsCancelled { get; set; }
    public DateTime? TrialEndsAt { get; set; }
    public DateTime? CancelledAt { get; set; }
}
```

It looks simple, but it accepts impossible data:

```csharp
IsTrial = true
IsActive = true
IsCancelled = true
TrialEndsAt = null
CancelledAt = null
```

The object compiles. The domain cries.

## Version 2 — enum plus nullable data

An enum improves the model:

```csharp
public enum SubscriptionStatus
{
    Trial,
    Active,
    Cancelled
}
```

Now there is one primary status. But the data can still drift away from the status.

A trial subscription can still have no trial end date. A cancelled subscription can still have no cancellation date.

## Version 3 — each state owns its data

Use a type for each valid state:

```csharp
public abstract record SubscriptionState;
public sealed record Trial(DateTime EndsAt) : SubscriptionState;
public sealed record Active : SubscriptionState;
public sealed record Cancelled(DateTime CancelledAt) : SubscriptionState;
```

Now each state carries only the data that makes sense for that state.

- `Trial` has `EndsAt`.
- `Active` has no useless nullable baggage.
- `Cancelled` has `CancelledAt`.

## Behavior becomes clearer

Pattern matching now follows the model:

```csharp
public static string GetStatusMessage(Subscription subscription) =>
    subscription.State switch
    {
        Trial trial => $"Trial ends on {trial.EndsAt:d}",
        Active => "Subscription is active",
        Cancelled cancelled => $"Subscription was cancelled on {cancelled.CancelledAt:d}",
        _ => "Unknown subscription state"
    };
```

## Trade-off

This does not remove all validation. You still need business rules for transitions.

It does remove many invalid shapes.

## Self-check

- Which invalid combinations disappeared?
- Which business rules still need explicit validation?
- Is the model easier or harder to serialize?
