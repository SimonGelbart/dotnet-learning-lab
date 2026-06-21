# dotnet-learning-lab

Learning paths, talks, exercises, samples, and benchmarks for modern .NET backend development.

This repository starts with an English-first path on **Modern C# Type Design**. The original French talks are kept as archived source material, while the public learning experience is being shaped as a short, practical web course.

Published site, once GitHub Pages is enabled:

```text
https://SimonGelbart.github.io/dotnet-learning-lab/
```

## Learning paths

| Path | Status | Focus |
| --- | --- | --- |
| [Modern C# Type Design](learning-paths/modern-csharp-type-design/) | Course blueprint | Identity vs value, record equality, stable keys, strongly typed IDs, value objects, valid state modeling, and JSON trade-offs. |
| [Modern C# Type System working material](learning-paths/modern-csharp-type-system/) | Working material | Existing lessons, samples, benchmarks, and archived talks used to shape the public course. |

## Course design

The first course is intentionally scoped to 45-60 minutes and does not require local setup. Runnable samples and benchmarks remain useful, but they are optional follow-up material rather than the first learner experience.

Start with:

- [Course design](docs/course-design.md)
- [Content model](docs/content-model.md)
- [Modern C# Type Design outline](learning-paths/modern-csharp-type-design/outline.md)

## Repository structure

```text
docs/
  course-design.md          # teaching direction
  content-model.md          # folder and content ownership

learning-paths/
  modern-csharp-type-design/
    index.md                # future public course entry point
    outline.md              # course arc and timing
    decision-guide.md       # durable takeaway
    modules/                # guided learning modules
    reference/              # lookup material
    labs/                   # optional local work

  modern-csharp-type-system/
    README.md               # current working material
    modules/                # existing split lessons
    docs/                   # supporting notes
    talks/                  # archived French presentations
    src/                    # runnable samples and benchmarks

tools/                      # local helper scripts
```

## Requirements

- .NET SDK 8 or newer for optional labs and samples.
- Optional: a modern browser and VS Code once the generated HTML decks are restored.
- Optional: VS Code, if you want local `vscode://file` links from the archived presentations.

## Quick start

The core course does not require local setup.

Run all current samples only if you want to inspect the working material locally:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --all
dotnet run --project learning-paths/modern-csharp-type-system/src/MemoryTypes.Samples -- --all
```

Validate the local setup:

```bash
./tools/validate-before-talk.sh
```

## Current scope

This is intentionally a learning lab, not a polished course platform yet. The first goal is to turn the type-design talk material into a clear 45-60 minute web learning path with short lessons, prediction questions, decision rules, and optional follow-up labs.
