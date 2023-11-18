using fleet_management.Data;
using fleet_management.Models;
using FleetModel_management.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fleet_management.Repositories
{
    public class FleetRepository : IFleetRepository
    {
        private readonly AppDbContext _dbContext;

        public FleetRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Fleet>> GetAll()
        {
            return await _dbContext.Fleets.ToListAsync();
        }

        public async Task<Fleet?> GetById(Guid id)
        {
            return await _dbContext.Fleets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Fleet> Add(Fleet fleet)
        {
            await _dbContext.Fleets.AddAsync(fleet);
            await _dbContext.SaveChangesAsync();

            return fleet;
        }

        public async Task<Fleet> Update(Guid id, Fleet fleet)
        {
            Fleet findFleetById = await GetById(id) ?? throw new Exception($"Usuário com o ID: {id} não encontrado");

            findFleetById.Name = fleet.Name;
            findFleetById.Cnpj = fleet.Cnpj;

            _dbContext.Fleets.Update(findFleetById);
            await _dbContext.SaveChangesAsync();

            return findFleetById;
        }

        public async Task<bool> Delete(Guid id)
        {
            Fleet fleet = await GetById(id) ?? throw new Exception($"Usuário com o ID: {id} não encontrado");

            _dbContext.Fleets.Remove(fleet);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}