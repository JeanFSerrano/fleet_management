using fleet_management.Models;

namespace fleet_management.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<VehicleModel>> GetAll();

        Task<VehicleModel?> GetById(Guid id);

        Task<VehicleModel> Add(VehicleModel vehicle);

        Task<VehicleModel> Update(Guid id, VehicleModel vehicle);

        Task<bool> Delete(Guid id);
    }
}