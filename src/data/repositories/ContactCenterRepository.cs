
using Microsoft.EntityFrameworkCore;

public class ContactCenterRepository : IContactCenterRepository
{
    public ContactCenterRepository()
    {
        using var context = new ContactCenterContext();
        context.Database.EnsureCreated();
    }

    public async Task<ContactCenter?> GetContactCenterAsync(Guid orgId, Guid contactCenterId)
    {
        ContactCenter? result = null;

        using (var context = new ContactCenterContext())
        {
            result = await context.ContactCenters.SingleOrDefaultAsync(o => o.OrgId.Equals(orgId) && o.Id.Equals(contactCenterId));
        }

        return result;
    }

    public async Task<List<ContactCenter>> GetContactCentersAsync(Guid orgId)
    {
        List<ContactCenter> result;

        using (var context = new ContactCenterContext())
        {
            result = await context.ContactCenters.Where(o => o.OrgId.Equals(orgId)).ToListAsync();

            foreach (var contactCenter in await context.ContactCenters.Where(o => o.OrgId.Equals(orgId)).ToListAsync())
            {
                contactCenter.OrgNodes = await context.ContactCenterOrgNodes.Where(o => o.ContactCenterId.Equals(contactCenter.Id)).ToListAsync();
                contactCenter.Agents = await context.Agents.Where(o => o.ContactCenterId.Equals(contactCenter.Id)).ToListAsync();
                contactCenter.Queues = await context.Queues.Where(o => o.ContactCenterId.Equals(contactCenter.Id)).ToListAsync();
            }
        }

        return result;
    }
}