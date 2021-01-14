using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Manufacturer
{
    [Authorize]
    public class DeleteModel : PageModel
    {

        public DeleteModel(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [BindProperty]
        public Core.Models.Manufacturer Manufacturer { get; set; }
        public IManufacturerService _manufacturerService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _manufacturerService.GetSingleById(id.Value);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _manufacturerService.Delete(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
