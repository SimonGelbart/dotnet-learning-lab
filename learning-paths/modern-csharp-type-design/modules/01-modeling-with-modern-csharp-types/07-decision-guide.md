# 07 - Decision guide

## Mission

Leave with a practical rule of thumb.

Modern C# type design is not about using new syntax everywhere. It is about making intent visible and invalid usage harder.

## The guide

| Question | Likely choice | Why |
| --- | --- | --- |
| Does the thing have identity, lifecycle, behavior, or shared mutable state? | `class` | The object represents something that remains the same entity over time. |
| Is this a data contract, message, event, command, or snapshot? | `record class` | The type is data-oriented and equality by data is often useful. |
| Is this a small stable business value? | `readonly record struct` | The type wraps meaning around a small value and should not change after creation. |
| Is this just a simple label with no attached data? | `enum` | A closed list of names is enough when no state-specific data exists. |
| Does each state carry different data? | record hierarchy + pattern matching | The data can live with the state that makes it valid. |
| Will this be a `Dictionary<TKey, TValue>` key or `HashSet<T>` item? | stable immutable value | Equality and hash code must remain stable after insertion. |
| Is this part of a public API or JSON contract? | design the contract explicitly | The internal model and external wire shape do not have to be identical. |

## Rules to keep close to the keyboard

- Use `class` when identity matters.
- Use `record class` when data equality is useful and reference type behavior is acceptable.
- Use `readonly record struct` for small stable values such as typed IDs and simple value objects.
- Avoid mutable dictionary keys.
- Do not say "record means immutable". Talk about actual mutability.
- Prefer `enum` for simple statuses without extra data.
- Prefer explicit state types when the state determines which data is valid.
- Treat JSON as a contract, not as an accident of internal modeling.

## Final check

For each model, pick a likely type shape:

```text
Customer
CustomerId
ProductKey
InvoicePaidEvent
SubscriptionStatus
TrialSubscriptionState
Money
```

One reasonable answer:

- `Customer`: `class`.
- `CustomerId`: `readonly record struct`.
- `ProductKey`: `readonly record struct`.
- `InvoicePaidEvent`: `record class`.
- `SubscriptionStatus`: `enum`, if it is only a label.
- `TrialSubscriptionState`: record in a state hierarchy.
- `Money`: `readonly record struct` or richer value object.

## Closing idea

A type is not just storage. It is a small contract with every caller.

When the type says the right thing, the correct code becomes easier to write.

Optional next step: [Exercises](exercises.md).
