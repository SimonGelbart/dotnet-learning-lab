# dotnet-learning-lab

Learning paths, talks, exercises, samples, and benchmarks for modern .NET backend development.

This repository starts with an English-first path on **Modern C# Type Design**. The original French talks are kept as archived source material, while the public learning experience is organized as short written lessons with runnable samples.

Published site, once GitHub Pages is enabled:

```text
https://SimonGelbart.github.io/dotnet-learning-lab/
```

## Learning paths

| Path | Status | Focus |
| --- | --- | --- |
| [Modern C# Type Design](learning-paths/modern-csharp-type-system/) | In progress | Records, value semantics, strongly typed IDs, stable dictionary keys, value objects, type-driven state modeling, and later memory-oriented .NET types. |

## Repository structure

```text
learning-paths/
  modern-csharp-type-system/
    README.md                 # GitHub overview
    modules/                  # Markdown modules rendered by GitHub Pages
    docs/                     # Supporting notes
    talks/                    # Archived French presentations
    src/                      # Runnable samples and benchmarks

tools/                        # Local helper scripts
```

## Requirements

- .NET SDK 8 or newer.
- Optional: a modern browser and VS Code once the generated HTML decks are restored.
- Optional: VS Code, if you want local `vscode://file` links from the archived presentations.

## Quick start

Run all samples:

```bash
dotnet run --project learning-paths/modern-csharp-type-system/src/DomainTypes.Samples -- --all
dotnet run --project learning-paths/modern-csharp-type-system/src/MemoryTypes.Samples -- --all
```

Validate the local setup:

```bash
./tools/validate-before-talk.sh
```

## Current scope

This is intentionally a learning lab, not a polished course. The first goal is to turn the type-design material into a clean web learning path with short lessons, runnable samples, and exercises.
