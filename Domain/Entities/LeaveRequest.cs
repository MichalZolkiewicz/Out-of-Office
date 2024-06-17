using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("LeaveRequests")]
public class LeaveRequest
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Employee Employee { get; set; }

    [Required]
    public string AbsenceReason { get; set; }

    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set;}

    public string Comment { get; set; }

    [Required]
    [MaxLength(100)]
    public string Status { get; set; }
}
