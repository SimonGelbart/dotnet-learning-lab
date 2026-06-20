namespace MemoryTypes.Samples.Demos;

public static class StackallocDemo
{
    public static void Run()
    {
        Span<int> buffer = stackalloc int[4];
        buffer[0] = 10;
        buffer[1] = 20;
        buffer[2] = 30;
        buffer[3] = 40;

        var sum = 0;
        foreach (var value in buffer)
            sum += value;

        Console.WriteLine($"Buffer length : {buffer.Length}");
        Console.WriteLine($"Sum           : {sum}");
        Console.WriteLine("The buffer is temporary and does not allocate on the managed heap.");
    }
}
