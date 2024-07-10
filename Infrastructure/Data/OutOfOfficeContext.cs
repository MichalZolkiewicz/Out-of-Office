using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class OutOfOfficeContext : IdentityDbContext<User>
{
    public OutOfOfficeContext(DbContextOptions<OutOfOfficeContext> options)
        : base(options)
    {

    }

    public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<Project> Projects { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(x => x.Users)
            .WithOne(x => x.PeoplePartner)
            .HasForeignKey(x => x.PeoplePartnerId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
