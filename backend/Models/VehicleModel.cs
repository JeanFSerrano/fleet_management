using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using fleet_management.Enums;

namespace fleet_management.Models
{
    [Table("Vehicle")]
    public class VehicleModel
    {
        [Key]
        [NotNull]
        public Guid Id { get; set; }

        public string? Type { get; set; }

        public int Seats { get; set; }

        public string? Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public long KmDriven { get; set; }

        public byte RunningDoors { get; set; }

        public byte NormalDoors { get; set; }

        public List<Fleet> Fleets { get; set; } = new();

        public Guid FleetId { get; set; }
    }
}