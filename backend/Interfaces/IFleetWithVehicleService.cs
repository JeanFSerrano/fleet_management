using fleet_management.Models;

namespace fleet_management.Interfaces
{
    public interface IFleetWithVehicleService
    {
        Task<List<FleetWithVehicleCount>> GetFleetAndItsVehicles();
    }
}