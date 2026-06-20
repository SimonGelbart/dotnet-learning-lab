namespace DomainTypes.Samples.Demos;

public static class StronglyTypedIdsDemo
{
    public static void Run()
    {
        var customerId = new CustomerId(Guid.NewGuid());
        var orderId = new OrderId(Guid.NewGuid());
        var service = new OrderService();

        Console.WriteLine($"CustomerId : {customerId}");
        Console.WriteLine($"OrderId    : {orderId}");
        Console.WriteLine();
        service.CancelOrder(orderId);
        Console.WriteLine();
        Console.WriteLine("The compiler prevents this mix-up:");
        Console.WriteLine("service.CancelOrder(customerId); // cannot convert CustomerId to OrderId");
    }

    public readonly record struct CustomerId(Guid Value);
    public readonly record struct OrderId(Guid Value);

    public sealed class OrderService
    {
        public void CancelOrder(OrderId orderId)
            => Console.WriteLine($"Cancelling order {orderId.Value}");
    }
}
