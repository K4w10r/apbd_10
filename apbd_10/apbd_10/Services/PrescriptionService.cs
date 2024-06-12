using apbd_10.DTOs;
using apbd_10.Repositories;

namespace apbd_10.Services;

public class PrescriptionService : IPrescriptionService
{
    private IPrescriptionRepository _prescriptionRepository;
    private IPatientRepository _patientRepository;
    private IDoctorRepository _doctorRepository;
    private IPrescriptionMedicamentRepository _prescriptionMedicamentRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository, IPrescriptionMedicamentRepository prescriptionMedicamentRepository)
    {
        _prescriptionRepository = prescriptionRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _prescriptionMedicamentRepository = prescriptionMedicamentRepository;
    }

    public async Task AddPrescriptionAsync(AssignPrescriptionDto assignPrescriptionDto)
    {
        try
        {
            var patientId = assignPrescriptionDto.Patient.IdPatient;
            var patientExists = await _patientRepository.PatientExistsAsync(patientId);
            if (!patientExists)
            {
                patientId = await _patientRepository.AddPatientAsync(assignPrescriptionDto.Patient);
            }

            var doctorId = assignPrescriptionDto.Doctor.IdDoctor;
            var doctorExists = await _doctorRepository.DoctorExistsAsync(doctorId);
            if (!doctorExists)
            {
                throw new Exception("Doctor doesn't exist");
            }

            if (assignPrescriptionDto.Medicaments.ToList().Count > 10)
            {
                throw new Exception("Too many medications (max 10)");
            }

            if (assignPrescriptionDto.DueDate < assignPrescriptionDto.Date)
            {
                throw new Exception("Due date already expired");
            }
            
            var prescriptionId =
                await _prescriptionRepository.AddPrescriptionAsync(assignPrescriptionDto, patientId, doctorId);
            var prescriptionMedicament = 0;
            if (prescriptionId != 0)
            {
                prescriptionMedicament =
                    await _prescriptionMedicamentRepository.AddToPrescriptionMedicamentAsync(
                        assignPrescriptionDto.Medicaments,
                        prescriptionId);
            }
        }
        catch (Exception e)
        { //handle exeptions
        }
    }
}