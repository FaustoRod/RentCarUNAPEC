using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapecApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [Route("ManufacturerWithModels")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetManufacturers()
        {
            var manufacturers = await _manufacturerService.GetAllWithModels();
            if (!manufacturers.Any())
            {
                return NotFound(new SelectList(manufacturers, nameof(Manufacturer.Id), nameof(Manufacturer.Description)));
            }
            return Ok(new SelectList(manufacturers, nameof(Manufacturer.Id), nameof(Manufacturer.Description)));
        }

        [Route("ManufacturerAll")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetManufacturersAll()
        {
            var manufacturers = await _manufacturerService.GetAll();
            if (!manufacturers.Any())
            {
                return NotFound(new SelectList(manufacturers, nameof(Manufacturer.Id), nameof(Manufacturer.Description)));
            }
            return Ok(new SelectList(manufacturers, nameof(Manufacturer.Id), nameof(Manufacturer.Description)));
        }
    }
}
