namespace DomainTypes.Samples.Demos;

public static class MutableKeyPitfallDemo
{
    public static void Run()
    {
        var key = new MutableProductKey { Sku = "ABC", Country = "FR" };
        var prices = new Dictionary<MutableProductKey, decimal>();
        prices[key] = 19.99m;

        Console.WriteLine("Before mutation");
        Console.WriteLine($"Key               : {key}");
        Console.WriteLine($"Contains same key : {prices.ContainsKey(key)}");
        Console.WriteLine($"Hash code         : {key.GetHashCode()}");
        Console.WriteLine();

        key.Country = "US";

        Console.WriteLine("After mutation");
        Console.WriteLine($"Key               : {key}");
        Console.WriteLine($"Contains same key : {prices.ContainsKey(key)}");
        Console.WriteLine($"Hash code         : {key.GetHashCode()}");
        Console.WriteLine();
        Console.WriteLine("A dictionary key must be stable after insertion.");
    }

    private sealed record MutableProductKey
    {
        public string Sku { get; set; } = "";
        public string Country { get; set; } = "";
    }
}
