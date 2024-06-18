using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Employees")]
public class Employee
{
    [Key]
    public int Id { get; set; }

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
    public int PeoplePartner { get; set; }

    [Required]
    public int AbsenceBalance { get; set; }
}
