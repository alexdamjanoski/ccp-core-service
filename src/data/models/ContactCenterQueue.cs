public class ContactCenterQueue
{
    public Guid Id { get; set; }

    public Guid ContactCenterId { get; set; }

    public bool CanHandlePhones { get; set; }

    public bool CanHandleText { get; set; }

    public bool CanHandleChat { get; set; }

    public RoutingStrategyEnum RoutingStrategy { get; set; }

    public required DateTime Created_At { get; set; }

    public required DateTime Updated_At { get; set; }
}

public enum RoutingStrategyEnum
{
    RoundRobin = 1
}