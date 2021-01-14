using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.FuelTankState
{
    [Authorize]
    public class EditModel : PageModel
    {

        public EditModel(IFuelTankStateService fuelTankStateService)
        {
            _fuelTankStateService = fuelTankStateService;
        }

        [BindProperty]
        public Core.Models.FuelTankState FuelTankState { get; set; }
        public IFuelTankStateService _fuelTankStateService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FuelTankState = await _fuelTankStateService.GetSingleById(id.Value);

            if (FuelTankState == null)
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
            await _fuelTankStateService.Update(FuelTankState);

            return RedirectToPage("./Index");
        }

    }
}
