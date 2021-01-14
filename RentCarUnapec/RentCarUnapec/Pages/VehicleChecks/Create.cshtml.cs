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
    public class CreateModel : PageModel
    {
        private readonly IVehicleCheckService _vehicleCheckService;
        private readonly ICarRentInformationService _carRentInformationService;
        private readonly IFuelTankStateService _fuelTankStateService;
        public SelectList FuelTankList;

        public CreateModel(IVehicleCheckService vehicleCheckService,ICarRentInformationService carRentInformationService,IFuelTankStateService fuelTankStateService)
        {
            _vehicleCheckService = vehicleCheckService;
            _carRentInformationService = carRentInformationService;
            _fuelTankStateService = fuelTankStateService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarRentInformationId = id.Value;
            await LoadList();
            CarRentInformation = await _carRentInformationService.GetSingleById(id.Value);

            return Page();
        }

        [BindProperty]
        public VehicleCheck VehicleCheck { get; set; }
        [BindProperty]
        public int CarRentInformationId { get; set; }
        public Core.Models.CarRentInformation CarRentInformation { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CarRentInformation = await _carRentInformationService.GetSingleById(CarRentInformationId);
                await LoadList();
                return Page();
            }

            VehicleCheck.EmployeeId = 1;
            VehicleCheck.CarRentInformationId = CarRentInformationId;
            await _vehicleCheckService.Create(VehicleCheck);

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
