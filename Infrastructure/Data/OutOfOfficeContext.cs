using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class OutOfOfficeContext : DbContext
{
    public OutOfOfficeContext(DbContextOptions<OutOfOfficeContext> options)
        : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }  
    public DbSet<Project> Projects { get; set; }   

}
