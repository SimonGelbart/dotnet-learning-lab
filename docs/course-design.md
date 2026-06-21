# Course Design

This repository publishes practical learning paths for modern .NET backend development.

It is not only a sample-code repository, and it is not meant to mirror API documentation. The learning material should help a developer build judgement, not just copy syntax.

## First course

The first course is **Modern C# Type Design**.

Course promise:

> Design backend models that make invalid code harder to write.

The course is based on the original live talk about the modern C# type system, but the web version should read as a focused learning path rather than as slide notes.

## Audience

Primary audience:

- intermediate C# / .NET backend developers;
- developers who already write application code;
- developers who want clearer rules for choosing between `class`, `record class`, `record struct`, `readonly record struct`, `enum`, and explicit state models.

The course does not assume advanced performance knowledge. The focus is correctness, API clarity, domain modeling, and trade-offs.

## Duration

Target duration: **45-60 minutes**.

This constraint is intentional. The first public version should be short enough to complete in one sitting.

## Teaching style

Use the live talk as the spine:

1. start with a memorable rule;
2. introduce one modeling problem at a time;
3. ask the learner to predict behavior before explaining it;
4. keep examples short and practical;
5. show the trade-off, not only the recommended option;
6. end each lesson with a rule of thumb.

The recurring lesson shape is:

```text
Mission
Problem
Naive version
Better model
Why it works
Trade-off
Check yourself
Rule of thumb
```

## Core idea

A good type makes the valid path natural and the invalid path harder to write.

This should remain visible throughout the course. Modern C# features are not the point by themselves. The point is using type choices to express intent.

## Learning devices

Prefer:

- prediction questions;
- small code-reading exercises;
- classification questions;
- refactoring prompts;
- decision tables;
- short case studies.

Avoid making local setup mandatory in the first version. Runnable samples, benchmarks, and full coding labs are useful as optional follow-up material.

## Non-goals for the first version

The first version should not try to be:

- a complete C# type-system reference;
- a performance course;
- a full domain-driven design course;
- a serialization deep dive;
- a workshop that requires cloning and running code before learning anything.
