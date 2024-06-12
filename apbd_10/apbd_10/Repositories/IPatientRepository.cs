using apbd_10.DTOs;

namespace apbd_10.Repositories;

public interface IPatientRepository
{
    public Task<bool> PatientExistsAsync(int idPatient);
    public Task<int> AddPatientAsync(PatientDto patientDto);
    public Task<GetPatientDto> GetPatientDataAsync(int idPatient);
}