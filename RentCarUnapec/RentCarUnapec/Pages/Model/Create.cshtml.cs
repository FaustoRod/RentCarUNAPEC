using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Model
{
    [Authorize]
    public class CreateModel : PageModel
    {

        public CreateModel(IModelService modelService,IManufacturerService manufacturerService)
        {
            _modelService = modelService;
            _manufacturerService = manufacturerService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ManufacturerListItem = new SelectList(await _manufacturerService.GetAll(), nameof(Core.Models.Manufacturer.Id), nameof(Core.Models.Manufacturer.Description));
            return Page();
        }

        [BindProperty]
        public Core.Models.Model Model { get; set; }
        public SelectList ManufacturerListItem { get; set; }
        public IModelService _modelService { get; }
        public IManufacturerService _manufacturerService { get; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ManufacturerListItem = new SelectList(await _manufacturerService.GetAll(), nameof(Core.Models.Manufacturer.Id), nameof(Core.Models.Manufacturer.Description));
                return Page();
            }

            await _modelService.Create(Model);

            return RedirectToPage("./Index");
        }
    }
}
