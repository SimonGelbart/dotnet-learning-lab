using DomainTypes.Samples.Demos;

var demos = new SortedDictionary<string, Action>(StringComparer.OrdinalIgnoreCase)
{
    ["collections"] = CollectionsEqualityDemo.Run,
    ["copying"] = CopyingDemo.Run,
    ["ids"] = StronglyTypedIdsDemo.Run,
    ["money"] = MoneyDemo.Run,
    ["mutable-key"] = MutableKeyPitfallDemo.Run,
    ["record-struct"] = RecordStructMutabilityDemo.Run,
    ["serialization"] = SubscriptionSerializationDemo.Run,
    ["state-modeling"] = SubscriptionStateModelingDemo.Run
};

if (args.Contains("--all", StringComparer.OrdinalIgnoreCase))
{
    foreach (var demo in demos)
    {
        PrintHeader(demo.Key);
        demo.Value();
        Console.WriteLine();
    }
    return;
}

var demoArgIndex = Array.FindIndex(args, a => string.Equals(a, "--demo", StringComparison.OrdinalIgnoreCase));
if (demoArgIndex >= 0 && demoArgIndex + 1 < args.Length)
{
    var name = args[demoArgIndex + 1];
    if (demos.TryGetValue(name, out var selectedDemo))
    {
        PrintHeader(name);
        selectedDemo();
        return;
    }

    Console.WriteLine($"Unknown demo: {name}");
}

PrintUsage(demos.Keys);

static void PrintUsage(IEnumerable<string> demoNames)
{
    Console.WriteLine("Types C# applicatifs — samples");
    Console.WriteLine("Usage:");
    Console.WriteLine("  dotnet run -- --all");
    Console.WriteLine("  dotnet run -- --demo <name>");
    Console.WriteLine("Available demos:");
    foreach (var key in demoNames) Console.WriteLine($"  - {key}");
}

static void PrintHeader(string title)
{
    Console.WriteLine(new string('=', 72));
    Console.WriteLine(title);
    Console.WriteLine(new string('=', 72));
}
