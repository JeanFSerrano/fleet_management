using fleet_management.Data;
using fleet_management.Interfaces;
using fleet_management.Migrations;
using fleet_management.Models;
using Microsoft.EntityFrameworkCore;

namespace fleet_management.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly AppDbContext _db;

        public VehicleService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<VehicleModel>> MostDrivenVehicles()
        {
            var mostDrivenVehicles = await _db.Vehicles
                .OrderByDescending(v => v.KmDriven)
                .Select(v => new VehicleModel
                {
                    Brand = v.Brand,
                    Model = v.Model,
                    KmDriven = v.KmDriven
                })
                .ToListAsync();

            return mostDrivenVehicles;
        }

    }
}