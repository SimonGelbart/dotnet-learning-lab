using MemoryTypes.Samples.Demos;

var demos = new SortedDictionary<string, Func<Task>>(StringComparer.OrdinalIgnoreCase)
{
    ["memory-async"] = async () => await MemoryAsyncDemo.RunAsync(),
    ["parser"] = () => { CsvSpanParserDemo.Run(); return Task.CompletedTask; },
    ["pool"] = () => { MemoryPoolDemo.Run(); return Task.CompletedTask; },
    ["split"] = () => { SplitVsSpanDemo.Run(); return Task.CompletedTask; },
    ["stackalloc"] = () => { StackallocDemo.Run(); return Task.CompletedTask; }
};

if (args.Contains("--all", StringComparer.OrdinalIgnoreCase))
{
    foreach (var demo in demos)
    {
        PrintHeader(demo.Key);
        await demo.Value();
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
        await selectedDemo();
        return;
    }
    Console.WriteLine($"Unknown demo: {name}");
}

PrintUsage(demos.Keys);

static void PrintUsage(IEnumerable<string> demoNames)
{
    Console.WriteLine("Types mémoire .NET — samples");
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
