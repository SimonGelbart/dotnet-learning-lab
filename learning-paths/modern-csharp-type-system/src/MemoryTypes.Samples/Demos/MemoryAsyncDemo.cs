namespace MemoryTypes.Samples.Demos;

public static class MemoryAsyncDemo
{
    public static async Task RunAsync()
    {
        ReadOnlyMemory<char> line = "Alice,Paris,Developer".AsMemory();
        var count = await CountColumnsAsync(line);
        Console.WriteLine($"Column count : {count}");
    }

    private static async Task<int> CountColumnsAsync(ReadOnlyMemory<char> line)
    {
        await Task.Yield();

        // ReadOnlyMemory<T> can cross the async boundary.
        // The Span is created only inside a synchronous helper.
        return CountColumns(line);
    }

    private static int CountColumns(ReadOnlyMemory<char> line)
    {
        ReadOnlySpan<char> span = line.Span;
        var count = 1;

        foreach (var ch in span)
        {
            if (ch == ',') count++;
        }

        return count;
    }
}
