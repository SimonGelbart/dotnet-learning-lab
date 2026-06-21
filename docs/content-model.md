# Content Model

This document defines how learning content should be organized before the GitHub Pages redesign.

The structure should work as plain Markdown now and map cleanly to Astro/Starlight later.

## Top-level responsibilities

```text
docs/
  Course design and publishing guidance.

learning-paths/
  Public learning paths and their modules.

src/
  Runnable code used by optional labs and examples.

tools/
  Local helper scripts.
```

## Learning path structure

A learning path should use this shape:

```text
learning-paths/<path-slug>/
  index.md
  outline.md
  decision-guide.md

  modules/
    01-<module-slug>/
      index.md
      01-<lesson>.md
      02-<lesson>.md
      exercises.md

  reference/
    <lookup-material>.md

  labs/
    README.md

  archive/
    <historical-material>/
```

## What belongs where

### `index.md`

The public landing page for the path.

It should answer:

- who this is for;
- what problem it solves;
- how long it takes;
- what the learner will be able to decide or do;
- where to start.

### `outline.md`

The canonical course plan.

It should include:

- parts or modules;
- expected timing;
- learning outcomes;
- the narrative arc.

### `modules/`

Guided learning content in reading order.

A module should feel like a short course section, not a documentation category. Lessons should be small, sequential, and outcome-driven.

### `reference/`

Durable lookup material.

Examples:

- cheat sheets;
- decision guides;
- syntax notes;
- equality and hashing reminders;
- serialization notes.

Reference material is for revisiting after the lesson, not for the first explanation.

### `labs/`

Optional local practice.

Labs may require cloning, building, running examples, or editing code. They should not be required for the first pass through a course.

### `archive/`

Historical talks and source material.

Archive material can be valuable, but it should not compete with the guided learner path.

## Current transition

The existing `modern-csharp-type-system` folder remains the working material. The `modern-csharp-type-design` folder defines the future public course shape.

A later PR can move or redirect content after the Astro/Starlight publishing model is chosen.
