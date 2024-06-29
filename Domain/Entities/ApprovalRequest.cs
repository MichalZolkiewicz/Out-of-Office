using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("ApprovalRequests")]
public class ApprovalRequest
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string ApproverId { get; set; }
    public User Approver { get; set; }

    [Required]
    public int LeaveRequestId { get; set; }

    public LeaveRequest LeaveRequest { get; set; }

    [Required]
    public string Status { get; set; }

    [MaxLength(1000)]
    public string Comment { get; set; }
}
