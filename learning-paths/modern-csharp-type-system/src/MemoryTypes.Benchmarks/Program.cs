using BenchmarkDotNet.Running;
using MemoryTypes.Benchmarks.Benchmarks;

BenchmarkSwitcher.FromTypes([
    typeof(CsvParsingBenchmarks),
    typeof(StackallocBenchmarks)
]).Run(args);
