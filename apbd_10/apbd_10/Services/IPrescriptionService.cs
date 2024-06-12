using apbd_10.DTOs;

namespace apbd_10.Services;

public interface IPrescriptionService
{
    public Task AddPrescriptionAsync(AssignPrescriptionDto assignPrescriptionDto);
}