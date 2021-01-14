using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.VehicleColor
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        public DeleteModel(IVehicleColorService vehicleColorService)
        {
            _vehicleColorService = vehicleColorService;
        }

        [BindProperty]
        public Core.Models.VehicleColor VehicleColor { get; set; }
        public IVehicleColorService _vehicleColorService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleColor = await _vehicleColorService.GetSingleById(id.Value);

            if (VehicleColor == null)
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

            await _vehicleColorService.Delete(id.Value);    

            return RedirectToPage("./Index");
        }
    }
}
