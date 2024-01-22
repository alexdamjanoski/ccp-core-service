public class ContactCenterDto
{
    public ContactCenterDto()
    {
        this.OrgNodes = new List<ContactCenterOrgNodeDto>();
        this.Agents = new List<ContactCenterAgentDto>();
        this.Queues = new List<ContactCenterQueueDto>();
    }

    public Guid Id { get; set; }

    public required Guid OrgId { get; set; }

    public required string Name { get; set; }

    public string? EnterpriseHubId { get; set; }

    public required ContactCenterStatusEnum Status { get; set; }

    public List<ContactCenterOrgNodeDto> OrgNodes { get; set; }

    public List<ContactCenterAgentDto> Agents { get; set; }

    public List<ContactCenterQueueDto> Queues { get; set; }

    public required DateTime Created_At { get; set; }

    public required DateTime Updated_At { get; set; }
}