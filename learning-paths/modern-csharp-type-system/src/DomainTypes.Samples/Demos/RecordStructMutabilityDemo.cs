namespace DomainTypes.Samples.Demos;

public static class RecordStructMutabilityDemo
{
    public static void Run()
    {
        var mutable = new MutableMoney(10, "EUR");
        mutable.Amount = -999;
        mutable.Currency = "";

        Console.WriteLine("record struct is mutable by default");
        Console.WriteLine(mutable);
        Console.WriteLine();

        var immutable = new ImmutableMoney(10, "EUR");
        var updated = immutable with { Amount = 12 };

        Console.WriteLine("readonly record struct is immutable-ish");
        Console.WriteLine($"original : {immutable}");
        Console.WriteLine($"updated  : {updated}");
    }

    private record struct MutableMoney(decimal Amount, string Currency);
    private readonly record struct ImmutableMoney(decimal Amount, string Currency);
}
