using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fleet_management.Models;

namespace fleet_management.Interfaces
{
    public interface IVehicleService
    {
        Task<List<VehicleModel>> MostDrivenVehicles();
    }
}