$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$PathRoot = Join-Path $Root "learning-paths/modern-csharp-type-system"
Set-Location $Root

Write-Host "== DomainTypes.Samples =="
dotnet build (Join-Path $PathRoot "src/DomainTypes.Samples")

Write-Host "== DomainTypes.Benchmarks =="
dotnet build (Join-Path $PathRoot "src/DomainTypes.Benchmarks") -c Release

Write-Host "== MemoryTypes.Samples =="
dotnet build (Join-Path $PathRoot "src/MemoryTypes.Samples")

Write-Host "== MemoryTypes.Benchmarks =="
dotnet build (Join-Path $PathRoot "src/MemoryTypes.Benchmarks") -c Release

Write-Host "== Run samples =="
dotnet run --project (Join-Path $PathRoot "src/DomainTypes.Samples") -- --all
dotnet run --project (Join-Path $PathRoot "src/MemoryTypes.Samples") -- --all

Write-Host "Validation OK"
