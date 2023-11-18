using fleet_management.Models;
using Microsoft.EntityFrameworkCore;

namespace fleet_management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Fleet> Fleets { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<FleetWithVehicleCount> FleetAndVehicles { get; set; }
    }
}