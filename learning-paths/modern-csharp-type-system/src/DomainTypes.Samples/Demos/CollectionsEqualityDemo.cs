namespace DomainTypes.Samples.Demos;

public static class CollectionsEqualityDemo
{
    public static void Run()
    {
        HashSetWithClass();
        Console.WriteLine();
        HashSetWithRecord();
        Console.WriteLine();
        DictionaryWithClassWithoutComparer();
        Console.WriteLine();
        DictionaryWithClassAndComparer();
        Console.WriteLine();
        DictionaryWithReadonlyRecordStruct();
    }

    private static void HashSetWithClass()
    {
        var a = new ProductKeyClass("ABC", "FR");
        var b = new ProductKeyClass("ABC", "FR");
        var set = new HashSet<ProductKeyClass> { a, b };

        Console.WriteLine("HashSet<class>");
        Console.WriteLine($"ReferenceEquals(a, b) : {ReferenceEquals(a, b)}");
        Console.WriteLine($"set.Count             : {set.Count}");
    }

    private static void HashSetWithRecord()
    {
        var a = new ProductKeyRecord("ABC", "FR");
        var b = new ProductKeyRecord("ABC", "FR");
        var set = new HashSet<ProductKeyRecord> { a, b };

        Console.WriteLine("HashSet<record class>");
        Console.WriteLine($"a == b    : {a == b}");
        Console.WriteLine($"set.Count : {set.Count}");
    }

    private static void DictionaryWithClassWithoutComparer()
    {
        var prices = new Dictionary<ProductKeyClass, decimal>();
        prices[new ProductKeyClass("ABC", "FR")] = 19.99m;

        Console.WriteLine("Dictionary<class, decimal> without comparer");
        Console.WriteLine($"Contains equivalent key : {prices.ContainsKey(new ProductKeyClass("ABC", "FR"))}");
    }

    private static void DictionaryWithClassAndComparer()
    {
        var prices = new Dictionary<ProductKeyClass, decimal>(new ProductKeyClassComparer());
        prices[new ProductKeyClass("ABC", "FR")] = 19.99m;

        Console.WriteLine("Dictionary<class, decimal> with IEqualityComparer");
        Console.WriteLine($"Contains equivalent key : {prices.ContainsKey(new ProductKeyClass("ABC", "FR"))}");
    }

    private static void DictionaryWithReadonlyRecordStruct()
    {
        var prices = new Dictionary<ProductKeyValue, decimal>();
        prices[new ProductKeyValue("ABC", "FR")] = 19.99m;

        Console.WriteLine("Dictionary<readonly record struct, decimal>");
        Console.WriteLine($"Contains equivalent key : {prices.ContainsKey(new ProductKeyValue("ABC", "FR"))}");
    }

    private sealed class ProductKeyClass
    {
        public ProductKeyClass(string sku, string country)
        {
            Sku = sku;
            Country = country;
        }
        public string Sku { get; }
        public string Country { get; }
    }

    private sealed class ProductKeyClassComparer : IEqualityComparer<ProductKeyClass>
    {
        public bool Equals(ProductKeyClass? x, ProductKeyClass? y)
            => ReferenceEquals(x, y) ||
               x is not null && y is not null && x.Sku == y.Sku && x.Country == y.Country;

        public int GetHashCode(ProductKeyClass obj)
            => HashCode.Combine(obj.Sku, obj.Country);
    }

    private sealed record ProductKeyRecord(string Sku, string Country);
    private readonly record struct ProductKeyValue(string Sku, string Country);
}
