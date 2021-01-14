using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.VehicleType
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        public DeleteModel(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        [BindProperty]
        public Core.Models.VehicleType VehicleType { get; set; }
        public IVehicleTypeService _vehicleTypeService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleType = await _vehicleTypeService.GetSingleById(id.Value);

            if (VehicleType == null)
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

            if (VehicleType != null)
            {
                await _vehicleTypeService.Delete(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
