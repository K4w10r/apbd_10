using apbd_10.Entities;
using Microsoft.EntityFrameworkCore;

namespace apbd_10;

public class MedicalContext : DbContext
{
    protected MedicalContext()
    {
    }
    public MedicalContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}