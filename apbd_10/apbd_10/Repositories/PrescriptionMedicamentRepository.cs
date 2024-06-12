using apbd_10.DTOs;
using apbd_10.Entities;

namespace apbd_10.Repositories;

public class PrescriptionMedicamentRepository : IPrescriptionMedicamentRepository
{
    private MedicalContext _medicalContext;

    public PrescriptionMedicamentRepository(MedicalContext medicalContext)
    {
        _medicalContext = medicalContext;
    }
    public async Task<int> AddToPrescriptionMedicamentAsync(IEnumerable<MedicamentDto> medicaments, int idPrescription)
    {
        foreach (var medicament in medicaments)
        {
            var prescriptionMedicament = new PrescriptionMedicament()
            {
                IdMedicament = medicament.IdMedicament, IdPrescription = idPrescription,
                Dose = medicament.Dose, Details = medicament.Description
            };
            _medicalContext.PrescriptionMedicaments.Add(prescriptionMedicament);
        }

        return await _medicalContext.SaveChangesAsync();;
    }
}