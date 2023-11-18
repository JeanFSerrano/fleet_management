using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace fleet_management.Models
{
    [Keyless]
    public class FleetWithVehicleCount
    {
        public string? Fleet { get; set; }
        public List<string>? VehicleName { get; set; }
        public int VehicleCount { get; set; }
    }
}