using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.VehicleChecks
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IVehicleCheckService _vehicleCheckService;
        private readonly IFuelTankStateService _fuelTankStateService;

        public EditModel(IVehicleCheckService vehicleCheckService, IFuelTankStateService fuelTankStateService)
        {
            _vehicleCheckService = vehicleCheckService;
            _fuelTankStateService = fuelTankStateService;
        }

        [BindProperty]
        public VehicleCheck VehicleCheck { get; set; }
        [BindProperty]
        public int CarRentInformationId { get; set; }
        public Core.Models.CarRentInformation CarRentInformation { get; set; }
        public SelectList FuelTankList;

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

            CarRentInformation = VehicleCheck.CarRentInformation;

            await LoadList();
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

            await _vehicleCheckService.Update(VehicleCheck);

            return RedirectToPage("./Index");
        }
        private async Task LoadList()
        {
            FuelTankList = new SelectList(await _fuelTankStateService.GetAll(),
                nameof(Core.Models.FuelTankState.Id),
                nameof(Core.Models.FuelTankState.Description));
        }
    }
}
