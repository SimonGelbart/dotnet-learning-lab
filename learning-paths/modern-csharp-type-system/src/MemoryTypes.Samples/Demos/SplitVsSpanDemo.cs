namespace MemoryTypes.Samples.Demos;

public static class SplitVsSpanDemo
{
    public static void Run()
    {
        const string line = "Alice,Paris,Developer";

        var parts = line.Split(',');
        Console.WriteLine("string.Split materializes strings:");
        Console.WriteLine($"parts type : {parts.GetType().Name}");
        Console.WriteLine(string.Join(" | ", parts));
        Console.WriteLine();

        ReadOnlySpan<char> span = line;
        var comma = span.IndexOf(',');
        var first = span[..comma];
        Console.WriteLine("ReadOnlySpan<char> slices the original text:");
        Console.WriteLine($"first column : {first.ToString()}");
    }
}
