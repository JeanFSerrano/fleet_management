using fleet_management.Data;
using fleet_management.Interfaces;
using fleet_management.Models;
using Microsoft.EntityFrameworkCore;

namespace fleet_management.Services
{
    public class FleetService : IFleetWithVehicleService
    {
        private readonly AppDbContext _context;

        public FleetService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FleetWithVehicleCount>> GetFleetAndItsVehicles()
        {
            var fleetAndVehicles =
                _context.Fleets.GroupJoin(
                    _context.Vehicles,
                    fleet => fleet.Id,
                    vehicle => vehicle.FleetId,
                    (fleet, vehicles) => new
                    {
                        Fleet = fleet,
                        Vehicles = vehicles
                    }
                )
                .Select(result => new FleetWithVehicleCount
                {
                    Fleet = result.Fleet.Name,
                    VehicleCount = result.Vehicles.Count(),
                    VehicleName = result.Vehicles.Select(v => v.Model).ToList()
                });


            return await fleetAndVehicles.ToListAsync();
        }

    }
}