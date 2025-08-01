using Microsoft.AspNetCore.Mvc;
using VehicleManagement.Application.Dtos;
using VehicleManagement.Application.Interfaces;

namespace VehicleManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleManagementController : ControllerBase
    {        
        private readonly IVehicleManagementService _service;
        public VehicleManagementController(IVehicleManagementService service)
        {
            _service = service;
        }

        [HttpPost(Name = "Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateVehicleDto createVehicleDto)
        {
            var response = await _service.RegisterVehicleAsync(createVehicleDto);
            return Ok(response);
        }
    }
}
