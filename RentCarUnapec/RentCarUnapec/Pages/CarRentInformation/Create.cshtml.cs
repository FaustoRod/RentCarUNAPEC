using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Data.Interfaces;
using RentCarUnapec.Helpers;

namespace RentCarUnapec.Pages.CarRentInformation
{
    [Authorize]
    public class CreateModel : PageModel
    {

        public CreateModel(ICarRentInformationService carRentInformationService, IVehicleService vehicleService, IClientService clientService)
        {
            _carRentInformationService = carRentInformationService;
            _vehicleService = vehicleService;
            _clientService = clientService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            RentDate = DateTime.Today;
            await GetSelectList();
            return Page();
        }

        [BindProperty]
        public Core.Models.CarRentInformation CarRentInformation { get; set; }
        [DataType(DataType.Date)]
        public DateTime RentDate { get; set; }
        public SelectList VehicleList { get; set; }
        public SelectList ClientList { get; set; }
        private ICarRentInformationService _carRentInformationService { get; }
        private IVehicleService _vehicleService { get; }
        private IClientService _clientService { get; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("CarRentInformation.RentSequence");
            if (!ModelState.IsValid)
            {
                RentDate = DateTime.Today;
                await GetSelectList();
                return Page();
            }

            CarRentInformation.EmployeeId = UserInfo.Instance.EmployeeId;

            CarRentInformation.RentDay = DateTime.Today;
            if (await _carRentInformationService.Create(CarRentInformation))
            {
                return RedirectToPage("./Index");
            }

            RentDate = DateTime.Today;
            await GetSelectList();
            return Page();
        }

        private async Task GetSelectList()
        {
            VehicleList = new SelectList(await _vehicleService.GetListByState(Core.Enums.VehicleStateEnum.Disponible), nameof(Core.Models.Vehicle.Id), nameof(Core.Models.Vehicle.VehicleFullName));
            ClientList = new SelectList(await _clientService.GetAll(), nameof(Core.Models.Client.Id), nameof(Core.Models.Client.Name));
        }
    }
}
