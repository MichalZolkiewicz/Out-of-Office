using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Projects")]
public class Project
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string ProjectType { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int ProjectManagerId { get; set; }

    [Required]
    public Employee ProjectManager { get; set; }

    public string Comment { get; set; }

    [Required]
    public string Status { get; set; }
}
