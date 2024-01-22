public class ContactCenterAgentDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required DateTime Created_At { get; set; }

    public required DateTime Updated_At { get; set; }
}