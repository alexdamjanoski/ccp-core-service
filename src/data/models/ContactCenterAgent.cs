public class ContactCenterAgent
{
    public Guid Id { get; set; }

    public Guid ContactCenterId { get; set; }

    public required string Name { get; set; }

    public required DateTime Created_At { get; set; }

    public required DateTime Updated_At { get; set; }
}