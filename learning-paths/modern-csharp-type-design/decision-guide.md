# Modern C# Type Decision Guide

Use this as the durable takeaway from the course.

| Question | Likely choice | Why |
| --- | --- | --- |
| Does the thing have identity, lifecycle, behavior, or shared mutable state? | `class` | The object represents something that remains the same entity over time. |
| Is this a data contract, message, event, command, or snapshot? | `record class` | The type is data-oriented and equality by data is often useful. |
| Is this a small stable business value? | `readonly record struct` | The type wraps meaning around a small value and should not change after creation. |
| Is this just a simple label with no attached data? | `enum` | A closed list of names is enough when no state-specific data exists. |
| Does each state carry different data? | record hierarchy + pattern matching | The data can live with the state that makes it valid. |
| Will this be a `Dictionary<TKey, TValue>` key or `HashSet<T>` item? | stable immutable value | Equality and hash code must remain stable after insertion. |
| Is this part of a public API or JSON contract? | design the contract explicitly | The internal model and external wire shape do not have to be identical. |

## Rules of thumb

- Use `class` when identity matters.
- Use `record class` when data equality is useful but reference type behavior is acceptable.
- Use `readonly record struct` for small stable values such as typed IDs and simple value objects.
- Avoid mutable dictionary keys.
- Do not say "record means immutable". Talk about the actual mutability of the type and its members.
- Prefer `enum` for simple statuses without extra data.
- Prefer explicit state types when the state determines which data is valid.
- Treat JSON as a contract, not as a side effect of internal domain modeling.
