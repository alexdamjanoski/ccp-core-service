public class ContactCenterOrgNodeDto
{
    public Guid Id { get; set; }

    public required Guid OrgId { get; set; }

    public required DateTime Created_At { get; set; }

    public required DateTime Updated_At { get; set; }
}