using fleet_management.Interfaces;
using fleet_management.Models;
using fleet_management.Services;
using Microsoft.AspNetCore.Mvc;

namespace fleet_management.Controllers
{
    [ApiController]
    [Route("fleet_and_vehicles")]
    public class FleetWitVehicleController : Controller
    {

        private readonly IFleetWithVehicleService _service;

        public FleetWitVehicleController(IFleetWithVehicleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<FleetWithVehicleCount>>> GetFleetAndVehicles()
        {

            List<FleetWithVehicleCount> fleetsAndVehicles = await _service.GetFleetAndItsVehicles();

            return Ok(fleetsAndVehicles);
        }
    }
}