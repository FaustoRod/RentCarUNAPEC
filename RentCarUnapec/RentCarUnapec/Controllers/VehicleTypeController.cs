using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }
        public async Task<IActionResult> GetList()
        {
            return PartialView("~/Pages/VehicleType/_VehicleTypeList.cshtml", await _vehicleTypeService.GetAll());
        }
    }
}
