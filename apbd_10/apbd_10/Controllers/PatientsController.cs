using apbd_10.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }
    [HttpGet("{idPatient}")]
    public async Task<IActionResult> GetPatientData(int idPatient)
    {
        try
        {
            var patientData = await _patientService.GetPatientDataAsync(idPatient);

            return Ok(patientData);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}