using Microsoft.EntityFrameworkCore;

public class ContactCenterContext : DbContext
{
    public ContactCenterContext() : base() { }

    public DbSet<ContactCenter> ContactCenters { get; set; }

    public DbSet<ContactCenterOrgNode> ContactCenterOrgNodes { get; set; }

    public DbSet<ContactCenterAgent> Agents { get; set; }

    public DbSet<ContactCenterQueue> Queues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // modelBuilder.Entity<ContactCenter>()
        //      .HasMany(e => e.OrgNodes)
        //      .WithOne(e => e.ContactCenter)
        //      .HasForeignKey(e => e.ContactCenterId)
        //      .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<ContactCenter>().HasData(
            new ContactCenter
            {
                Id = new Guid("8447730d-9029-4f94-acac-61cf22088f4a"),
                OrgId = new Guid("32c82eea-4776-4a46-81b2-8e8d38535757"),
                Name = "Alex Call Center 1",
                Status = ContactCenterStatusEnum.Draft,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
            },
            new ContactCenter
            {
                Id = new Guid("66b9117d-d182-4b9e-bc52-7f9d731c223a"),
                OrgId = new Guid("32c82eea-4776-4a46-81b2-8e8d38535757"),
                Name = "Alex Call Center 2",
                Status = ContactCenterStatusEnum.Draft,
                OrgNodes = new List<ContactCenterOrgNode>(),
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
            },
            new ContactCenter
            {
                Id = new Guid("ec7646f2-efbc-4ccb-a151-16886e72f774"),
                OrgId = new Guid("26b953c0-baec-4e12-80ee-44d271a8caf9"),
                Name = "Dave Call Center 1",
                Status = ContactCenterStatusEnum.Draft,
                OrgNodes = new List<ContactCenterOrgNode>(),
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
            }
        );

        modelBuilder.Entity<ContactCenterOrgNode>().HasData(
            new ContactCenterOrgNode
            {
                Id = new Guid("c8949dab-686e-4eb7-bd42-1602fd0254ca"),
                OrgId = new Guid("7e68884f-0321-48d9-8a40-76d3989d89c6"),
                ContactCenterId = new Guid("8447730d-9029-4f94-acac-61cf22088f4a"),
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now
            },
            new ContactCenterOrgNode
            {
                Id = new Guid("22bd9279-1059-45e6-9bcc-62f1fcf68669"),
                OrgId = new Guid("33f3ff5b-9906-4339-89cf-ed86a735016b"),
                ContactCenterId = new Guid("8447730d-9029-4f94-acac-61cf22088f4a"),
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now
            }
        );

        modelBuilder.Entity<ContactCenterAgent>().HasData(
            new ContactCenterAgent
            {
                Id = new Guid("0e45e385-ae8c-4062-af5e-32ff3748cd81"),
                Name = "Dave",
                ContactCenterId = new Guid("8447730d-9029-4f94-acac-61cf22088f4a"),
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now
            },
            new ContactCenterAgent
            {
                Id = new Guid("eefe0780-b7dc-4f38-ac02-fbee452b0a74"),
                Name = "Alex",
                ContactCenterId = new Guid("8447730d-9029-4f94-acac-61cf22088f4a"),
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now
            }
        );

        modelBuilder.Entity<ContactCenterQueue>().HasData(
            new ContactCenterQueue
            {
                Id = new Guid("135e4144-d65d-4755-8183-87f01507cd2f"),
                CanHandleChat = true,
                CanHandlePhones = true,
                CanHandleText = false,
                RoutingStrategy = RoutingStrategyEnum.RoundRobin,
                ContactCenterId = new Guid("8447730d-9029-4f94-acac-61cf22088f4a"),
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now
            },
            new ContactCenterQueue
            {
                Id = new Guid("8cfb0cda-e3c6-4bce-a0c2-ba2474cea1d0"),
                CanHandleChat = false,
                CanHandlePhones = false,
                CanHandleText = true,
                RoutingStrategy = RoutingStrategyEnum.RoundRobin,
                ContactCenterId = new Guid("8447730d-9029-4f94-acac-61cf22088f4a"),
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=ContactCenterPro;User Id=sa;Password=S3rv!c3T!t@n;Encrypt=True;TrustServerCertificate=True");
    }


}