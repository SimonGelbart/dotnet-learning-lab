# Module 01 - Modeling with modern C# types

Mission:

> Use C# type shapes to make backend models clearer and harder to misuse.

This module is the first 45-60 minute guided path in **Modern C# Type Design**.

It is based on a live talk, but the web version is intentionally lighter: no required local setup, no benchmark detour, and no long syntax tour. Each lesson is a small modeling problem followed by a practical rule.

## Core idea

A good type makes the valid path natural and the invalid path harder to write.

Modern C# gives you more choices than `class` or `struct`. The goal is not to use every feature. The goal is to choose the shape that sends the right signal to the next developer reading the code.

```text
class                  -> identity, lifecycle, behavior
record class           -> data-oriented reference type, value equality
readonly record struct -> small stable value
```

## Reading path

| Lesson | Time | Focus |
| --- | ---: | --- |
| [01 - Identity or value?](01-identity-or-value.md) | 8 min | Choose the model's first signal. |
| [02 - Equality becomes visible](02-equality-becomes-visible.md) | 10 min | Predict record behavior in sets and dictionaries. |
| [03 - Stable keys and shallow immutability](03-stable-keys-and-immutability.md) | 8 min | Avoid collection bugs that compile cleanly. |
| [04 - Small business values](04-small-business-values.md) | 10 min | Use typed IDs and value objects to protect meaning. |
| [05 - Modeling valid states](05-modeling-valid-states.md) | 12 min | Move from flags to enum to dedicated state records. |
| [06 - JSON contracts](06-json-contracts.md) | 4 min | Name the trade-off at the wire boundary. |
| [07 - Decision guide](07-decision-guide.md) | 3 min | Keep practical rules close to the keyboard. |
| [Optional exercises](exercises.md) | optional | Refactor a small model step by step. |

## How to read it

Read the lessons in order. Pause on the prediction questions before opening the explanation. The goal is to train judgement, not memorize syntax.

No local setup is required for the first pass.

## Outcomes

By the end, you should be able to:

- classify a model as identity, data contract, small value, or state;
- predict basic record equality behavior;
- explain why collection keys must be stable;
- use strongly typed IDs to prevent swapped values;
- use value objects to hold small business rules;
- compare bool flags, enums, and dedicated state records;
- name the JSON trade-off introduced by stronger internal models;
- use a decision guide for common application type choices.
