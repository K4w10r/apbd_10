using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_10.Entities;

[Table("Doctor")]
public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}