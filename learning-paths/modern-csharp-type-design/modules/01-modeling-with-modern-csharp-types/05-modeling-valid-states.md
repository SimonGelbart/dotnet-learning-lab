# 05 - Modeling valid states

## Mission

Make impossible subscription states harder to represent.

Some models are not just values. They are states with rules.

## The problem

A subscription can be:

- in trial;
- active;
- cancelled.

Some data only makes sense in one state:

- `TrialEndsAt` belongs to trial;
- `CancelledAt` belongs to cancelled;
- active does not need either date.

## Version 1: bools and nullables

This is common and easy to write:

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

But it allows this:

```csharp
var subscription = new Subscription
{
    IsTrial = true,
    IsActive = true,
    IsCancelled = true,
    TrialEndsAt = null,
    CancelledAt = null
};
```

The object compiles, but the business meaning is broken.

## Version 2: enum status

An enum is already better.

```csharp
public enum SubscriptionStatus
{
    Trial,
    Active,
    Cancelled
}

public sealed class Subscription
{
    public SubscriptionStatus Status { get; set; }
    public DateTime? TrialEndsAt { get; set; }
    public DateTime? CancelledAt { get; set; }
}
```

This gives one status at a time.

But the dates are still detached from the status. A cancelled subscription can still have no `CancelledAt`, and an active subscription can still carry a trial end date.

## Version 3: dedicated state types

Model the valid states directly.

```csharp
public abstract record SubscriptionState;

public sealed record Trial(DateTime EndsAt) : SubscriptionState;
public sealed record Active : SubscriptionState;
public sealed record Cancelled(DateTime CancelledAt) : SubscriptionState;

public sealed class Subscription
{
    public required SubscriptionState State { get; init; }
}
```

Now the data lives with the state that makes it valid.

```csharp
var trial = new Subscription
{
    State = new Trial(DateTime.UtcNow.AddDays(14))
};

var active = new Subscription
{
    State = new Active()
};

var cancelled = new Subscription
{
    State = new Cancelled(DateTime.UtcNow)
};
```

## Pattern matching becomes simpler

With bools and nullables, code has to defend against invalid combinations.

With state records, each branch receives the data it needs.

```csharp
public static string GetStatusMessage(Subscription subscription) =>
    subscription.State switch
    {
        Trial trial =>
            $"Trial ends on {trial.EndsAt:d}",

        Active =>
            "Subscription is active",

        Cancelled cancelled =>
            $"Cancelled on {cancelled.CancelledAt:d}",

        _ =>
            "Unknown subscription state"
    };
```

The fallback is still useful because C# record hierarchies are not closed discriminated unions by default. But the normal cases are much clearer.

## Trade-off

The record-state model is stronger, but it is also more explicit. That is worth it when the invalid combinations are real and costly.

If the status is only a label with no attached data, an enum is often enough.

## Check yourself

When should you stop at an enum?

A good answer: when there is one status at a time and no state-specific required data.

## Rule of thumb

When a state determines which data is valid, consider making the state a type.

Next: [JSON contracts](06-json-contracts.md).
