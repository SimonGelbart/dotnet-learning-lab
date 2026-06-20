namespace DomainTypes.Samples.Demos;

public static class MoneyDemo
{
    public static void Run()
    {
        var price = new Money(10, "EUR");
        var tax = new Money(2, "EUR");
        var total = price.Add(tax);

        Console.WriteLine($"price : {price}");
        Console.WriteLine($"tax   : {tax}");
        Console.WriteLine($"total : {total}");
        Console.WriteLine();

        var invalidDefault = default(Money);
        Console.WriteLine("default(T) still exists for structs");
        Console.WriteLine($"default(Money) : {invalidDefault}");
    }

    private readonly record struct Money(decimal Amount, string Currency)
    {
        public Money Add(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Cannot add different currencies.");

            return this with { Amount = Amount + other.Amount };
        }
    }
}
