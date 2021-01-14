using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.VehicleType
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public CreateModel(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Core.Models.VehicleType VehicleType { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _vehicleTypeService.Create(VehicleType);

            return RedirectToPage("./Index");
        }
    }
}
