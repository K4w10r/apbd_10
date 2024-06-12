using apbd_10.DTOs;
using apbd_10.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private IPrescriptionService _prescriptionService;

    public PrescriptionsController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }
    [HttpPost]
    public async Task<IActionResult> AddPrescription(AssignPrescriptionDto assignPrescriptionDto)
    {
        await _prescriptionService.AddPrescriptionAsync(assignPrescriptionDto);
        
        return NoContent();
    }
}