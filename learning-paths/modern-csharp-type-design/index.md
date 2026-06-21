# Modern C# Type Design

Design backend models that make invalid code harder to write.

This is a 45-60 minute learning path for intermediate .NET backend developers who want clearer rules for choosing C# type shapes in application code.

The course is based on a live presentation about the modern C# type system, but the web version is designed as a short guided path: less setup, more judgement.

## Who this is for

This path is for you if you already write C# and want better answers to questions like:

- Should this be a `class`, `record class`, `record struct`, or `readonly record struct`?
- Should equality come from identity or from data?
- Why do `HashSet<T>` and `Dictionary<TKey, TValue>` expose equality mistakes so quickly?
- When does a strongly typed ID help?
- When is an `enum` enough, and when should a state become a type?
- What does a stronger domain model cost at the JSON boundary?

## What you will learn

By the end, you should be able to:

- distinguish identity types from value types;
- predict basic record equality behavior;
- explain why dictionary keys must stay stable;
- use strongly typed IDs to prevent swapped-parameter mistakes;
- use small value objects to protect business meaning;
- compare bool flags, enums, and dedicated state records;
- recognize serialization trade-offs when internal models become stronger;
- use a practical decision guide under delivery pressure.

## Start here

The first module is the complete initial course:

- [Module 01 - Modeling with modern C# types](modules/01-modeling-with-modern-csharp-types/)

It is designed to be read in order and completed in one sitting.

## Course path

1. [Identity or value?](modules/01-modeling-with-modern-csharp-types/01-identity-or-value.md)
2. [Equality becomes visible](modules/01-modeling-with-modern-csharp-types/02-equality-becomes-visible.md)
3. [Stable keys and shallow immutability](modules/01-modeling-with-modern-csharp-types/03-stable-keys-and-immutability.md)
4. [Small business values](modules/01-modeling-with-modern-csharp-types/04-small-business-values.md)
5. [Modeling valid states](modules/01-modeling-with-modern-csharp-types/05-modeling-valid-states.md)
6. [JSON contracts](modules/01-modeling-with-modern-csharp-types/06-json-contracts.md)
7. [Decision guide](modules/01-modeling-with-modern-csharp-types/07-decision-guide.md)
8. [Optional exercises](modules/01-modeling-with-modern-csharp-types/exercises.md)

## Local setup

No local setup is required for the first pass.

Optional labs and runnable samples can be added after the core path reads well.
