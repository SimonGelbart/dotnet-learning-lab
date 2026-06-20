# dotnet-learning-lab

Learning paths, talks, exercises, samples, and benchmarks for modern .NET backend development.

This repository starts with a practical path on the modern C# type system. The original material was prepared in French as two talks; the repository keeps those talks available while organizing the content as a reusable learning lab.

## Learning paths

| Path | Status | Focus |
| --- | --- | --- |
| [Modern C# type system](learning-paths/modern-csharp-type-system/) | In progress | Records, value semantics, strongly typed IDs, type-driven state modeling, `Span<T>`, `Memory<T>`, and allocation-aware design. |

## Repository structure

```text
learning-paths/
  modern-csharp-type-system/
    README.md                 # English overview
    README.fr.md              # French overview
    docs/                     # Supporting notes
    talks/                    # Original French presentations
    src/                      # Runnable samples and benchmarks

tools/                        # Local helper scripts
```

## Requirements

- .NET SDK 8 or newer.
- Optional: a modern browser and VS Code once the generated HTML decks are restored.
- Optional: VS Code, if you want local `vscode://file` links from the presentations.

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

Generate local VS Code links for the HTML presentations:

```bash
./tools/setup-local-links.sh
```

## Current scope

This is intentionally a learning lab, not a polished course yet. The first goal is to preserve the talks, samples, and benchmarks in a clean repository structure; written modules and exercises can be added progressively.
