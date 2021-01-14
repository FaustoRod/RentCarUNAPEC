using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetManufacturers()
        {
            return new JsonResult(new SelectList(await _manufacturerService.GetAllWithModels(), nameof(Manufacturer.Id), nameof(Manufacturer.Description)));
        }
    }
}
