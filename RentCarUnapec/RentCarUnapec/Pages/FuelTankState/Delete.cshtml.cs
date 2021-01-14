using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.FuelTankState
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        
        public DeleteModel(IFuelTankStateService fuelTankStateService)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _fuelTankStateService.Delete(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
