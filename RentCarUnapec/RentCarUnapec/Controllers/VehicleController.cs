using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Controllers
{
    public class VehicleController : Controller
    {
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        private IVehicleService _vehicleService { get; }

        public async Task<IActionResult> GetByManufacturer(int id)
        {
            var list = await _vehicleService.GetListByManufacturer(id);
            return PartialView("~/Pages/Vehicle/_VehicleTableResult.cshtml",list);
        }

        public async Task<IActionResult> GetByModel(int id)
        {
            var list = await _vehicleService.GetListByModel(id);
            return PartialView("~/Pages/Vehicle/_VehicleTableResult.cshtml",list);
        }

    }
}
