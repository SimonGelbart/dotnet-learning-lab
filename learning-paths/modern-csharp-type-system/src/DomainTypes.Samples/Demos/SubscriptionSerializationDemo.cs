using System.Text.Json;
using System.Text.Json.Serialization;

namespace DomainTypes.Samples.Demos;

public static class SubscriptionSerializationDemo
{
    public static void Run()
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            WriteIndented = true
        };

        var subscription = new Subscription
        {
            State = new Trial(new DateTime(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc))
        };

        var json = JsonSerializer.Serialize(subscription, options);
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);
        Console.WriteLine();

        var deserialized = JsonSerializer.Deserialize<Subscription>(json, options);
        Console.WriteLine($"Deserialized concrete state: {deserialized?.State.GetType().Name}");
        Console.WriteLine($"Status message: {GetStatusMessage(deserialized!)}");
    }

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "kind")]
    [JsonDerivedType(typeof(Trial), "trial")]
    [JsonDerivedType(typeof(Active), "active")]
    [JsonDerivedType(typeof(Cancelled), "cancelled")]
    public abstract record SubscriptionState;

    public sealed record Trial(DateTime EndsAt) : SubscriptionState;
    public sealed record Active : SubscriptionState;
    public sealed record Cancelled(DateTime CancelledAt) : SubscriptionState;

    public sealed class Subscription
    {
        public required SubscriptionState State { get; init; }
    }

    public static string GetStatusMessage(Subscription subscription) =>
        subscription.State switch
        {
            Trial trial => $"Trial ends on {trial.EndsAt:d}",
            Active => "Subscription is active",
            Cancelled cancelled => $"Subscription was cancelled on {cancelled.CancelledAt:d}",
            _ => "Unknown subscription state"
        };
}
