using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Vehicle
{
    [Authorize]
    public class DetailsModel : PageModel
    {

        public DetailsModel(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

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
    }
}
