using apbd_10.DTOs;

namespace apbd_10.Repositories;

public interface IPrescriptionRepository
{
    public Task<int> AddPrescriptionAsync(AssignPrescriptionDto assignPrescriptionDto, int doctorId, int patientId);
}