using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Vehicle
{
    [Authorize]
    public class DeleteModel : PageModel
    {

        public DeleteModel(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [BindProperty]
        public Core.Models.Vehicle Vehicle { get; set; }
        public IVehicleService _vehicleService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehicle = await _vehicleService.GetSingleById(id.Value);

            if (Vehicle == null)
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

            await _vehicleService.Delete(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
