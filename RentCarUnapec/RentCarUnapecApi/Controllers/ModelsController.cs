using System.Collections.Generic;
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
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model>>> GetModels()
        {
            var models = await _modelService.GetAll();

            return models;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetModelById(int id)
        {
            var model = await _modelService.GetSingleById(id);
            if (model == null)
            {
                return NotFound(false);
            }

            return Ok(model);
        }

        [HttpGet("ByManufacturer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetModelsByManufacturer(int id)
        {
            var model = await _modelService.GetModelByManufacturer(id);
            if (model == null)
            {
                return NotFound(new SelectList(new List<Model>(), nameof(Model.Id), nameof(Model.Description)));
            }

            return Ok(new SelectList(model,nameof(Model.Id), nameof(Model.Description)));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> PostCreate(Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.ValidationState);
            }

            var result = await _modelService.Create(model);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> PutEdit(Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.ValidationState);
            }

            var result = await _modelService.Update(model);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var result = await _modelService.Delete(id);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
