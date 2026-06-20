using BenchmarkDotNet.Attributes;

namespace MemoryTypes.Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class CsvParsingBenchmarks
{
    private const string Line = "Alice,Paris,Developer,Platform,42";

    [Benchmark(Baseline = true)]
    public int StringSplit()
    {
        var parts = Line.Split(',');
        var sum = 0;
        foreach (var part in parts) sum += part.Length;
        return sum;
    }

    [Benchmark]
    public int ReadOnlySpanParser()
    {
        ReadOnlySpan<char> remaining = Line;
        var sum = 0;

        while (!remaining.IsEmpty)
        {
            var commaIndex = remaining.IndexOf(',');
            if (commaIndex < 0)
            {
                sum += remaining.Length;
                break;
            }

            sum += remaining[..commaIndex].Length;
            remaining = remaining[(commaIndex + 1)..];
        }

        return sum;
    }
}
