using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.FuelType
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        public DeleteModel(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        [BindProperty]
        public Core.Models.FuelType FuelType { get; set; }
        public IFuelTypeService _fuelTypeService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FuelType = await _fuelTypeService.GetSingleById(id.Value);

            if (FuelType == null)
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

            await _fuelTypeService.Delete(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
