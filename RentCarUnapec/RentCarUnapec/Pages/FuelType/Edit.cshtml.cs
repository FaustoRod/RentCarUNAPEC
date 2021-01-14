using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.FuelType
{
    [Authorize]
    public class EditModel : PageModel
    {
        public EditModel(IFuelTypeService fuelTypeService)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _fuelTypeService.Update(FuelType);

            return RedirectToPage("./Index");
        }

    }
}
