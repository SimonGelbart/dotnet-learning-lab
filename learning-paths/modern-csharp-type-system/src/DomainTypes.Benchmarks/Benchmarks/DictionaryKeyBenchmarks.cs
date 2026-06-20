using BenchmarkDotNet.Attributes;

namespace DomainTypes.Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class DictionaryKeyBenchmarks
{
    private readonly Dictionary<string, decimal> _stringPrices = new();
    private readonly Dictionary<ProductKeyClass, decimal> _classPrices = new(new ProductKeyClassComparer());
    private readonly Dictionary<ProductKeyRecord, decimal> _recordPrices = new();
    private readonly Dictionary<ProductKeyValue, decimal> _valuePrices = new();

    private string _stringLookupKey = null!;
    private ProductKeyClass _classLookupKey = null!;
    private ProductKeyRecord _recordLookupKey = null!;
    private ProductKeyValue _valueLookupKey;

    [GlobalSetup]
    public void Setup()
    {
        _stringPrices["ABC|FR"] = 19.99m;
        _classPrices[new ProductKeyClass("ABC", "FR")] = 19.99m;
        _recordPrices[new ProductKeyRecord("ABC", "FR")] = 19.99m;
        _valuePrices[new ProductKeyValue("ABC", "FR")] = 19.99m;

        _stringLookupKey = "ABC|FR";
        _classLookupKey = new ProductKeyClass("ABC", "FR");
        _recordLookupKey = new ProductKeyRecord("ABC", "FR");
        _valueLookupKey = new ProductKeyValue("ABC", "FR");
    }

    [Benchmark(Baseline = true)]
    public bool StringKey() => _stringPrices.ContainsKey(_stringLookupKey);

    [Benchmark]
    public bool ClassKeyWithComparer() => _classPrices.ContainsKey(_classLookupKey);

    [Benchmark]
    public bool RecordClassKey() => _recordPrices.ContainsKey(_recordLookupKey);

    [Benchmark]
    public bool ReadonlyRecordStructKey() => _valuePrices.ContainsKey(_valueLookupKey);

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
