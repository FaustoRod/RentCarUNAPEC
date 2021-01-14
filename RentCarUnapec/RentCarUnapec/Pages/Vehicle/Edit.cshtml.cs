using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Vehicle
{
    [Authorize]
    public class EditModel : PageModel
    {
        public EditModel(IVehicleService vehicleService, IVehicleColorService vehicleColorService, IFuelTypeService fuelTypeService,
            IModelService modelService, IManufacturerService manufacturerService, ITransmissionTypeService transmissionTypeService, IVehicleTypeService vehicleTypeService)
        {
            _vehicleService = vehicleService;
            _vehicleColorService = vehicleColorService;
            _fuelTypeService = fuelTypeService;
            _modelService = modelService;
            _manufacturerService = manufacturerService;
            _transmissionTypeService = transmissionTypeService;
            _vehicleTypeService = vehicleTypeService;
        }
        [BindProperty]
        public Core.Models.Vehicle Vehicle { get; set; }
        [BindProperty]
        public int ManufacturerId { get; set; }
        public SelectList ColorList { get; set; }
        public SelectList FuelTypeList { get; set; }
        public SelectList ManufacturerList { get; set; }
        public SelectList ModelList { get; set; }
        public SelectList TransmissionList { get; set; }
        public SelectList VehicleTypeList { get; set; }


        public IVehicleService _vehicleService { get; }
        public IVehicleColorService _vehicleColorService { get; }
        public IFuelTypeService _fuelTypeService { get; }
        public IModelService _modelService { get; }
        public IManufacturerService _manufacturerService { get; }
        public ITransmissionTypeService _transmissionTypeService { get; }
        public IVehicleTypeService _vehicleTypeService { get; }

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

            ManufacturerId = Vehicle.Model.ManufacturerId;
            await LoadSelectListAsync();
            await LoadModelSelectListAsync();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectListAsync();
                await LoadModelSelectListAsync();
                return Page();
            }

            await _vehicleService.Update(Vehicle);

            return RedirectToPage("./Index");
        }
        public async Task<JsonResult> OnGetGetModelListAsync(int id)
        {
            return new JsonResult(new SelectList(await _modelService.GetModelByManufacturer(id), nameof(Core.Models.Model.Id), nameof(Core.Models.Model.Description)));
        }

        private async Task LoadSelectListAsync()
        {
            ManufacturerList = new SelectList(await _manufacturerService.GetAll(), nameof(Core.Models.Manufacturer.Id), nameof(Core.Models.Manufacturer.Description));
            ColorList = new SelectList(await _vehicleColorService.GetAll(), nameof(Core.Models.VehicleColor.Id), nameof(Core.Models.VehicleColor.Description));
            FuelTypeList = new SelectList(await _fuelTypeService.GetAll(), nameof(Core.Models.FuelType.Id), nameof(Core.Models.VehicleColor.Description));
            TransmissionList = new SelectList(await _transmissionTypeService.GetAll(), nameof(Core.Models.TransmissionType.Id), nameof(Core.Models.TransmissionType.Description));
            VehicleTypeList = new SelectList(await _vehicleTypeService.GetAll(), nameof(Core.Models.VehicleType.Id), nameof(Core.Models.VehicleType.Description));
        }

        private async Task LoadModelSelectListAsync()
        {
            ModelList = new SelectList(await _modelService.GetModelByManufacturer(ManufacturerId), nameof(Core.Models.Model.Id), nameof(Core.Models.Model.Description));
        }

    }
}
