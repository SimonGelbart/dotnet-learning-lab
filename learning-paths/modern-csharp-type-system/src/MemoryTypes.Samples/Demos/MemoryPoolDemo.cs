using System.Buffers;

namespace MemoryTypes.Samples.Demos;

public static class MemoryPoolDemo
{
    public static void Run()
    {
        using IMemoryOwner<byte> owner = MemoryPool<byte>.Shared.Rent(16);
        Memory<byte> memory = owner.Memory[..16];
        Span<byte> span = memory.Span;

        for (var i = 0; i < span.Length; i++)
            span[i] = (byte)i;

        Console.WriteLine($"Rented bytes : {span.Length}");
        Console.WriteLine($"First        : {span[0]}");
        Console.WriteLine($"Last         : {span[^1]}");
        Console.WriteLine("Dispose returns the buffer to the pool.");
    }
}
