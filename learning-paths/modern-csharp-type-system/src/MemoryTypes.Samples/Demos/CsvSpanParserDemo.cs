namespace MemoryTypes.Samples.Demos;

public static class CsvSpanParserDemo
{
    public static void Run()
    {
        ReadOnlySpan<char> line = "Alice,Paris,Developer";
        var reader = new CsvLineReader(line);

        Console.WriteLine("CsvLineReader returns slices of the original line:");
        Console.WriteLine(reader.ReadNextColumn().ToString());
        Console.WriteLine(reader.ReadNextColumn().ToString());
        Console.WriteLine(reader.ReadNextColumn().ToString());
    }
}

public ref struct CsvLineReader
{
    private ReadOnlySpan<char> _line;

    public CsvLineReader(ReadOnlySpan<char> line)
    {
        _line = line;
    }

    public ReadOnlySpan<char> ReadNextColumn()
    {
        if (_line.IsEmpty)
            return ReadOnlySpan<char>.Empty;

        var commaIndex = _line.IndexOf(',');

        if (commaIndex < 0)
        {
            var result = _line;
            _line = ReadOnlySpan<char>.Empty;
            return result;
        }

        var column = _line[..commaIndex];
        _line = _line[(commaIndex + 1)..];
        return column;
    }
}
