namespace DomainTypes.Samples.Demos;

public static class SubscriptionStateModelingDemo
{
    public static void Run()
    {
        Console.WriteLine("1. Boolean model: invalid combinations compile");
        var impossible = new BooleanSubscription
        {
            IsTrial = true,
            IsActive = true,
            IsCancelled = true,
            TrialEndsAt = null,
            CancelledAt = null
        };
        Console.WriteLine($"Boolean subscription: trial={impossible.IsTrial}, active={impossible.IsActive}, cancelled={impossible.IsCancelled}");
        Console.WriteLine();

        Console.WriteLine("2. Enum model: one status, but data can still be incoherent");
        var stillInvalid = new EnumSubscription
        {
            Status = SubscriptionStatus.Trial,
            TrialEndsAt = null,
            CancelledAt = DateTime.UtcNow
        };
        Console.WriteLine($"Enum subscription: status={stillInvalid.Status}, trialEndsAt={stillInvalid.TrialEndsAt}, cancelledAt={stillInvalid.CancelledAt:u}");
        Console.WriteLine();

        Console.WriteLine("3. Type-driven model: the state owns the relevant data");
        var trial = new Subscription
        {
            State = new Trial(DateTime.UtcNow.AddDays(14))
        };
        var active = new Subscription { State = new Active() };
        var cancelled = new Subscription { State = new Cancelled(DateTime.UtcNow) };

        Console.WriteLine(GetStatusMessage(trial));
        Console.WriteLine(GetStatusMessage(active));
        Console.WriteLine(GetStatusMessage(cancelled));
    }

    public sealed class BooleanSubscription
    {
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime? TrialEndsAt { get; set; }
        public DateTime? CancelledAt { get; set; }
    }

    public enum SubscriptionStatus
    {
        Trial,
        Active,
        Cancelled
    }

    public sealed class EnumSubscription
    {
        public SubscriptionStatus Status { get; set; }
        public DateTime? TrialEndsAt { get; set; }
        public DateTime? CancelledAt { get; set; }
    }

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
