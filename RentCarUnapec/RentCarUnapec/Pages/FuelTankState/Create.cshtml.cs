using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.FuelTankState
{
    [Authorize]
    public class CreateModel : PageModel
    {

        public CreateModel(IFuelTankStateService fuelTankStateService)
        {
            _fuelTankStateService = fuelTankStateService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Core.Models.FuelTankState FuelTankState { get; set; }
        public IFuelTankStateService _fuelTankStateService { get; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _fuelTankStateService.Create(FuelTankState);

            return RedirectToPage("./Index");
        }
    }
}
