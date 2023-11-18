
using fleet_management.Models;

namespace FleetModel_management.Interfaces
{
    public interface IFleetRepository
    {
        Task<List<Fleet>> GetAll();

        Task<Fleet?> GetById(Guid id);

        Task<Fleet> Add(Fleet FleetModel);

        Task<Fleet> Update(Guid id, Fleet FleetModel);

        Task<bool> Delete(Guid id);
    }
}