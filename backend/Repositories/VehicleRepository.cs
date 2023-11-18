using fleet_management.Data;
using fleet_management.Interfaces;
using fleet_management.Models;
using Microsoft.EntityFrameworkCore;

namespace fleet_management.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _dbContext;

        public VehicleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VehicleModel>> GetAll()
        {
            return await _dbContext.Vehicles.ToListAsync();
        }

        public async Task<VehicleModel?> GetById(Guid id)
        {
            return await _dbContext.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<VehicleModel> Add(VehicleModel vehicle)
        {
            await _dbContext.Vehicles.AddAsync(vehicle);
            await _dbContext.SaveChangesAsync();

            return vehicle;
        }

        public async Task<bool> Delete(Guid id)
        {
            VehicleModel vehicle = await GetById(id) ?? throw new Exception($"Usuário com o ID: {id} não encontrado");

            _dbContext.Vehicles.Remove(vehicle);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<VehicleModel> Update(Guid id, VehicleModel vehicle)
        {
            VehicleModel findVehicleById = await GetById(id) ?? throw new Exception($"Usuário com o ID: {id} não encontrado");

            findVehicleById.Brand = vehicle.Brand;
            findVehicleById.Year = vehicle.Year;
            findVehicleById.Seats = vehicle.Seats;
            findVehicleById.KmDriven = vehicle.KmDriven;
            findVehicleById.Type = vehicle.Type;
            findVehicleById.RunningDoors = vehicle.RunningDoors;
            findVehicleById.NormalDoors = vehicle.NormalDoors;
            findVehicleById.Model = vehicle.Model;

            _dbContext.Vehicles.Update(findVehicleById);
            await _dbContext.SaveChangesAsync();

            return findVehicleById;
        }
    }
}