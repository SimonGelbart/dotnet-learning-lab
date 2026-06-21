# Module 01 - Modeling with modern C# types

Mission:

> Use C# type shapes to make backend models clearer and harder to misuse.

This module is the first 45-60 minute guided path in **Modern C# Type Design**.

It should feel like the web version of a successful live talk: short, progressive, concrete, and opinionated without pretending that one type shape is always best.

## Module outcomes

By the end, the learner should be able to:

- classify a model as identity, data contract, small value, or state;
- predict basic record equality behavior;
- explain why collection keys must be stable;
- use strongly typed IDs to prevent swapped values;
- use value objects to hold small business rules;
- compare bool flags, enums, and dedicated state records;
- name the JSON trade-off introduced by stronger internal models;
- use a decision guide for common application type choices.

## Reading path

The module should follow this order:

1. Orientation: type choice is a behavior contract.
2. Identity or value?
3. Equality becomes visible.
4. Stable keys and shallow immutability.
5. Small business values.
6. Modeling valid states.
7. Decision guide.

## Lesson template

Each lesson should keep the same lightweight shape:

```text
Mission
The problem
Naive version
Better model
Why it works
Trade-off
Check yourself
Rule of thumb
```

## Teaching constraints

- Keep each lesson short.
- Prefer prediction questions over long explanation.
- Use one modeling problem per lesson.
- Do not require local setup in the core path.
- Keep runnable examples and benchmarks as optional follow-up labs.
- Preserve at least one memorable teaching moment from the original talk in each lesson.

## Core idea

A good type makes the valid path natural and the invalid path harder to write.
