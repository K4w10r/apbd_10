using apbd_10.DTOs;

namespace apbd_10.Repositories;

public interface IPrescriptionMedicamentRepository
{
    public Task<int> AddToPrescriptionMedicamentAsync(IEnumerable<MedicamentDto> medicaments, int idPrescription);
}