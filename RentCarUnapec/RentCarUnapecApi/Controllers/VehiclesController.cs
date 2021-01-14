using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapecApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        [Route("Manufacturer/{id}")]
        public async Task<ActionResult> GetByManufacturer(int id)
        {
            var vehicles = await _vehicleService.GetListByManufacturer(id);
            return Ok(vehicles);
        }

        [HttpGet]
        [Route("Model/{id}")]
        public async Task<ActionResult> GetByModel(int id)
        {
            var vehicles = await _vehicleService.GetListByModel(id);
            return Ok(vehicles);
        }
    }
}
