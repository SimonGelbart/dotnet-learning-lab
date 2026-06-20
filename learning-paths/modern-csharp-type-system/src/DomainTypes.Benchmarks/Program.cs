using BenchmarkDotNet.Running;
using DomainTypes.Benchmarks.Benchmarks;

BenchmarkSwitcher.FromTypes([
    typeof(DictionaryKeyBenchmarks)
]).Run(args);
