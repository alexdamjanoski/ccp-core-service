public interface IContactCenterRepository
{
    public Task<List<ContactCenter>> GetContactCentersAsync(Guid orgId);

    public Task<ContactCenter?> GetContactCenterAsync(Guid orgId, Guid contactCenterId);
}