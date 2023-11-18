using fleet_management.Models;
using FleetModel_management.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fleet_management.Controllers
{
    [ApiController]
    [Route("fleets")]
    public class FleetController : Controller
    {
        private readonly IFleetRepository _fleetRepository;

        public FleetController(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fleet>>> GetAll()
        {
            List<Fleet> fleets = await _fleetRepository.GetAll();

            return Ok(fleets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fleet>> GetById(Guid id)
        {
            Fleet fleet = await _fleetRepository.GetById(id) ?? throw new Exception("Vehicle Not Found.");

            return Ok(fleet);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Fleet>> Update([FromBody] Fleet fleetModel, Guid id)
        {

            fleetModel.Id = id;
            Fleet fleet = await _fleetRepository.Update(id, fleetModel);

            return Ok(fleet);
        }

        [HttpPost("new")]
        public async Task<ActionResult<Fleet>> Create([FromBody] Fleet fleetModel)
        {

            Fleet newFleet = await _fleetRepository.Add(fleetModel);

            return Ok(newFleet);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Fleet>> Delete(Guid id)
        {
            bool fleetToDelete = await _fleetRepository.Delete(id);

            return Ok(fleetToDelete);
        }

    }
}