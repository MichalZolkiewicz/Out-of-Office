using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User : IdentityUser
{
    [Required]
    [MaxLength(200)]
    public string FullName { get; set; }

    [Required]
    [MaxLength(100)]
    public string Subdivision { get; set; }

    [Required]
    public string Position { get; set; }

    [Required]
    public bool ActiveEmployee { get; set; }

    [Required]
    public string PeoplePartnerId { get; set; }

    public User PeoplePartner { get; set; }

    [Required]
    public int AbsenceBalance { get; set; }

    public ICollection<ApprovalRequest> ApprovalRequests { get; set; }
    public ICollection<LeaveRequest> LeaveRequests { get; set; }

    public ICollection<User> Users { get; set; }
}
