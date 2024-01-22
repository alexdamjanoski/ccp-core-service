using Microsoft.AspNetCore.Mvc;

[Route("api/v1/[controller]")]
public class ContactCenterController : ControllerBase
{
    private readonly IContactCenterRepository _contactCenterRepository;

    public ContactCenterController(
        IContactCenterRepository contactCenterRepository)
    {
        _contactCenterRepository = contactCenterRepository;
    }

    [HttpGet]
    [Route("contactCenters/{orgId}")]
    public async Task<IActionResult> ContactCentersAsync(Guid orgId)
    {
        var data = await _contactCenterRepository.GetContactCentersAsync(orgId);
        var response = new List<ContactCenterDto>();

        foreach (ContactCenter contactCenter in data)
        {
            var contactCenterDto = new ContactCenterDto()
            {
                Id = contactCenter.Id,
                OrgId = contactCenter.OrgId,
                Name = contactCenter.Name,
                EnterpriseHubId = contactCenter.EnterpriseHubId,
                Status = contactCenter.Status,
                Created_At = contactCenter.Created_At,
                Updated_At = contactCenter.Updated_At
            };

            foreach (ContactCenterOrgNode contactCenterOrgNode in contactCenter.OrgNodes)
            {
                contactCenterDto.OrgNodes.Add(new ContactCenterOrgNodeDto()
                {
                    Id = contactCenterOrgNode.Id,
                    OrgId = contactCenterOrgNode.OrgId,
                    Created_At = contactCenterOrgNode.Created_At,
                    Updated_At = contactCenterOrgNode.Updated_At

                });
            }

            foreach (ContactCenterAgent contactCenterAgent in contactCenter.Agents)
            {
                contactCenterDto.Agents.Add(new ContactCenterAgentDto()
                {
                    Id = contactCenterAgent.Id,
                    Name = contactCenterAgent.Name,
                    Created_At = contactCenterAgent.Created_At,
                    Updated_At = contactCenterAgent.Updated_At

                });
            }

            foreach (ContactCenterQueue contactCenterQueue in contactCenter.Queues)
            {
                contactCenterDto.Queues.Add(new ContactCenterQueueDto()
                {
                    Id = contactCenterQueue.Id,
                    CanHandleChat = contactCenterQueue.CanHandleChat,
                    CanHandlePhones = contactCenterQueue.CanHandlePhones,
                    CanHandleText = contactCenterQueue.CanHandleText,
                    Created_At = contactCenterQueue.Created_At,
                    Updated_At = contactCenterQueue.Updated_At

                });
            }

            response.Add(contactCenterDto);
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("contactCenters/{orgId}/{contactCenterId}")]
    public async Task<IActionResult> ContactCentersAsync(Guid orgId, Guid contactCenterId)
    {
        var data = await _contactCenterRepository.GetContactCenterAsync(orgId, contactCenterId);

        if (data is null)
            return NotFound();

        var response = new ContactCenterDto()
        {
            Id = data.Id,
            OrgId = data.OrgId,
            Name = data.Name,
            EnterpriseHubId = data.EnterpriseHubId,
            Status = data.Status,
            Created_At = data.Created_At,
            Updated_At = data.Updated_At
        };

        return Ok(response);
    }

}