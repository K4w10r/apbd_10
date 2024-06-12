using apbd_10.DTOs;

namespace apbd_10.Services;

public interface IPatientService
{
    public Task<GetPatientDto> GetPatientDataAsync(int idPatient);
}