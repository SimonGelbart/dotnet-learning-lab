namespace DomainTypes.Samples.Demos;

public static class CopyingDemo
{
    public static void Run()
    {
        Console.WriteLine("1) class: assignment copies the reference");
        var cart1 = new ShoppingCart();
        var cart2 = cart1;
        cart2.Add("Keyboard");

        Console.WriteLine($"cart1.Items.Count = {cart1.Items.Count}");
        Console.WriteLine($"cart2.Items.Count = {cart2.Items.Count}");
        Console.WriteLine("Both variables point to the same object.");
        Console.WriteLine();

        Console.WriteLine("2) readonly record struct: assignment copies the value");
        var paris = new Coordinate(48.8566, 2.3522);
        var copy = paris with { Latitude = 0 };

        Console.WriteLine($"paris.Latitude = {paris.Latitude}");
        Console.WriteLine($"copy.Latitude  = {copy.Latitude}");
        Console.WriteLine("copy is a separate value.");
    }

    private sealed class ShoppingCart
    {
        private readonly List<string> _items = [];
        public IReadOnlyList<string> Items => _items;
        public void Add(string item) => _items.Add(item);
    }

    private readonly record struct Coordinate(double Latitude, double Longitude);
}
