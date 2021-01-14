using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapecApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypesController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public VehicleTypesController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        // GET: api/VehicleTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleType>>> GetVehicleTypes()
        {
            return Ok();
        }

        // GET: api/VehicleTypes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<VehicleType>> GetVehicleType(int id)
        //{
        //    var vehicleType = await _context.VehicleTypes.FindAsync(id);

        //    if (vehicleType == null)
        //    {
        //        return NotFound();
        //    }

        //    return vehicleType;
        //}

        // PUT: api/VehicleTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Edit")]
        public async Task<IActionResult> PutVehicleType(VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await _vehicleTypeService.Update(vehicleType);
            return result ? Ok(vehicleType) : ValidationProblem();
        }

        // POST: api/VehicleTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> PostVehicleType(VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await _vehicleTypeService.Create(vehicleType);
            return result ? Ok(vehicleType) : ValidationProblem();
        }
        public class Fuck 
        {
            public string Name { get; set; }
        }

        // DELETE: api/VehicleTypes/5
        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVehicleType(int id)
        {
            var result = await _vehicleTypeService.Delete(id);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

    }
}
