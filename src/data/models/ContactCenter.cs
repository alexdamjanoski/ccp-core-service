public class ContactCenter
{
    public ContactCenter()
    {
        this.OrgNodes = new List<ContactCenterOrgNode>();
        this.Queues = new List<ContactCenterQueue>();
        this.Agents = new List<ContactCenterAgent>();
    }

    public Guid Id { get; set; }

    public required Guid OrgId { get; set; }

    public required string Name { get; set; }

    public string? EnterpriseHubId { get; set; }

    public required ContactCenterStatusEnum Status { get; set; }

    public virtual ICollection<ContactCenterOrgNode> OrgNodes { get; set; }

    public virtual ICollection<ContactCenterQueue> Queues { get; set; }

    public virtual ICollection<ContactCenterAgent> Agents { get; set; }

    public required DateTime Created_At { get; set; }

    public required DateTime Updated_At { get; set; }
}

public enum ContactCenterStatusEnum
{
    Draft = 1,
    Live = 2
}