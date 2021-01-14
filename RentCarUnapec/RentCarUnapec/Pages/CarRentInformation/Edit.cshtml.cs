using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Core.Enums;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.CarRentInformation
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ICarRentInformationService _carRentInformationService;
        private readonly IVehicleService _vehicleService;
        private readonly IClientService _clientService;

        public EditModel(ICarRentInformationService carRentInformationService,IVehicleService vehicleService,IClientService clientService)
        {
            _carRentInformationService = carRentInformationService;
            _vehicleService = vehicleService;
            _clientService = clientService;
        }

        [BindProperty]
        public Core.Models.CarRentInformation CarRentInformation { get; set; }
        public SelectList VehicleList { get; set; }
        public SelectList ClientList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarRentInformation = await _carRentInformationService.GetSingleById(id.Value);

            if (CarRentInformation == null)
            {
                return NotFound();
            }

            await GetSelectList();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("CarRentInformation.RentSequence");
            if (!ModelState.IsValid)
            {
                await GetSelectList();
                return Page();
            }

            await _carRentInformationService.Update(CarRentInformation);

            return RedirectToPage("./Index");
        }
        private async Task GetSelectList()
        {
            VehicleList = new SelectList(await _vehicleService.GetAll(), nameof(Core.Models.Vehicle.Id), nameof(Core.Models.Vehicle.VehicleFullName));
            ClientList = new SelectList(await _clientService.GetAll(), nameof(Core.Models.Client.Id), nameof(Core.Models.Client.Name));
        }

        public async Task<RedirectToPageResult> OnPostCancel(int id)
        {
            await _carRentInformationService.ChangeState(id,RentStateEnum.Canceled);
            return RedirectToPage("./Index");
        }
    }
}
