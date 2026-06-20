using BenchmarkDotNet.Attributes;

namespace MemoryTypes.Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class StackallocBenchmarks
{
    [Benchmark(Baseline = true)]
    public int ArrayBuffer()
    {
        var buffer = new int[16];
        for (var i = 0; i < buffer.Length; i++) buffer[i] = i;
        return Sum(buffer);
    }

    [Benchmark]
    public int StackallocBuffer()
    {
        Span<int> buffer = stackalloc int[16];
        for (var i = 0; i < buffer.Length; i++) buffer[i] = i;
        return Sum(buffer);
    }

    private static int Sum(ReadOnlySpan<int> values)
    {
        var sum = 0;
        foreach (var value in values) sum += value;
        return sum;
    }
}
