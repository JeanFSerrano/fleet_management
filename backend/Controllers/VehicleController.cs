using fleet_management.Interfaces;
using fleet_management.Models;
using Microsoft.AspNetCore.Mvc;

namespace fleet_management.Controllers
{
    [ApiController]
    [Route("vehicles")]
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleRepository vehicleRepository, IVehicleService vehicleService)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleModel>>> GetAll()
        {
            List<VehicleModel> vehicles = await _vehicleRepository.GetAll();

            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> GetById(Guid id)
        {
            VehicleModel vehicle = await _vehicleRepository.GetById(id) ?? throw new Exception("Vehicle Not Found.");

            return Ok(vehicle);
        }

        [HttpGet("most-driven")]
        public async Task<ActionResult<List<VehicleModel>>> MostDriven()
        {
            List<VehicleModel> mostDrivenVehicles = await _vehicleService.MostDrivenVehicles();

            return Ok(mostDrivenVehicles);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleModel>> Update([FromBody] VehicleModel vehicleModel, Guid id)
        {

            vehicleModel.Id = id;
            VehicleModel vehicle = await _vehicleRepository.Update(id, vehicleModel);

            return Ok(vehicle);
        }

        [HttpPost("new")]
        public async Task<ActionResult<VehicleModel>> Create([FromBody] VehicleModel vehicleModel)
        {

            VehicleModel newVehicle = await _vehicleRepository.Add(vehicleModel);

            return Ok(newVehicle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModel>> Delete(Guid id)
        {
            bool vehicleToDelete = await _vehicleRepository.Delete(id);

            return Ok(vehicleToDelete);
        }
    }
}