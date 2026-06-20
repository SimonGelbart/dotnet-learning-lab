---
layout: module
title: 07 — Type-driven state modeling
description: Replace invalid flag combinations with explicit state types.
module_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/
module_label: Module 01
sample_command: dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --demo state-modeling
previous_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/06-record-structs/
previous_label: record struct vs readonly record struct
next_url: /learning-paths/modern-csharp-type-system/modules/01-modeling-with-modern-csharp-types/08-serialization/
next_label: Serialization notes
---

## Goal

Model valid states directly instead of allowing invalid combinations.

## Problem example

Boolean flags and nullable fields can represent impossible states:

```csharp
IsTrial = true
IsActive = true
IsCancelled = true
TrialEndsAt = null
CancelledAt = null
```

An enum is often better, but it may still leave state-specific data disconnected from the state.

## Better model

Use a type for each valid state:

```csharp
public abstract record SubscriptionState;
public sealed record Trial(DateTime EndsAt) : SubscriptionState;
public sealed record Active : SubscriptionState;
public sealed record Cancelled(DateTime CancelledAt) : SubscriptionState;
```

Now the state owns the data that is valid for that state.

## Self-check

- Which invalid combinations disappeared?
- Which business rules still need explicit validation?
- Would this model make your API contract simpler or more complex?
