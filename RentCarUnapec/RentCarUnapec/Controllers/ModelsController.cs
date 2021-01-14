using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        public async Task<IActionResult> Index()
        {
            return PartialView("~/Pages/Model/_ModelList.cshtml", await _modelService.GetAll());
        }

        public async Task<JsonResult> GetModelsByManufacturer(int id)
        {
            return new JsonResult(new SelectList(await _modelService.GetModelByManufacturer(id), nameof(Model.Id), nameof(Model.Description)));
        }
    }
}
