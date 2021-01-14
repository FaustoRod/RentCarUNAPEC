using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.VehicleColor
{
    [Authorize]
    public class CreateModel : PageModel
    {

        public CreateModel(IVehicleColorService vehicleColorService)
        {
            _vehicleColorService = vehicleColorService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Core.Models.VehicleColor VehicleColor { get; set; }
        public IVehicleColorService _vehicleColorService { get; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _vehicleColorService.Create(VehicleColor);

            return RedirectToPage("./Index");
        }
    }
}
