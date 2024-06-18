using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("ApprovalRequests")]
public class ApprovalRequest
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int Approver { get; set; }

    [Required]
    public int LeaveRequest { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Comment { get; set; }
}
