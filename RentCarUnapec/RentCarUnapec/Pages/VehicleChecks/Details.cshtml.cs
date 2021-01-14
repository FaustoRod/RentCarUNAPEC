using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.VehicleChecks
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IVehicleCheckService _vehicleCheckService;

        public DetailsModel(IVehicleCheckService vehicleCheckService)
        {
            _vehicleCheckService = vehicleCheckService;
        }

        public VehicleCheck VehicleCheck { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleCheck = await _vehicleCheckService.GetSingleById(id.Value);

            if (VehicleCheck == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
