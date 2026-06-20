#!/usr/bin/env bash
set -euo pipefail
ROOT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
PATH_ROOT="$ROOT_DIR/learning-paths/modern-csharp-type-system"
cd "$ROOT_DIR"

echo "== DomainTypes.Samples =="
dotnet build "$PATH_ROOT/src/DomainTypes.Samples"

echo "== DomainTypes.Benchmarks =="
dotnet build "$PATH_ROOT/src/DomainTypes.Benchmarks" -c Release

echo "== MemoryTypes.Samples =="
dotnet build "$PATH_ROOT/src/MemoryTypes.Samples"

echo "== MemoryTypes.Benchmarks =="
dotnet build "$PATH_ROOT/src/MemoryTypes.Benchmarks" -c Release

echo "== Run samples =="
dotnet run --project "$PATH_ROOT/src/DomainTypes.Samples" -- --all
dotnet run --project "$PATH_ROOT/src/MemoryTypes.Samples" -- --all

echo "Validation OK"
