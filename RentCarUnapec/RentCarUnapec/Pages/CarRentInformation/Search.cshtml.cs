using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.CarRentInformation
{
    public class SearchModel : PageModel
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IModelService _modelService;
        private readonly IRentStateService _rentStateService;
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly ICarRentInformationService _carRentInformationService;

        public SearchModel(ICarRentInformationService carRentInformationService,
            IManufacturerService manufacturerService,
            IModelService modelService,
            IRentStateService rentStateService,
            IVehicleTypeService vehicleTypeService)
        {
            _manufacturerService = manufacturerService;
            _modelService = modelService;
            _rentStateService = rentStateService;
            _vehicleTypeService = vehicleTypeService;
            _carRentInformationService = carRentInformationService;
        }

        public IList<Core.Models.CarRentInformation> CarRentInformation { get; set; }
        [Display(Name = "Cliente")]
        [BindProperty]
        public int ClientId { get; set; }

        [Display(Name = "Cliente")]
        [BindProperty]
        public string ClientName { get; set; }

        [Display(Name = "Marca")]
        [BindProperty]
        public int Manufacturer { get; set; }

        [Display(Name = "Modelo")]
        [BindProperty]
        public int Model { get; set; }

        [Display(Name = "Tipo")]
        [BindProperty]
        public int VehicleType { get; set; }

        [Display(Name = "Estado")]
        [BindProperty]
        public int State { get; set; }

        [Display(Name = "Desde:")]
        [DataType(DataType.Date)]
        [BindProperty]

        public DateTime FromDate { get; set; }
        [Display(Name = "Hasta:")]
        [DataType(DataType.Date)]
        [BindProperty]

        public DateTime ToDate { get; set; }
        [BindProperty]
        public bool SearchDone { get; set; }

        public SelectList ManufacturerList { get; set; }
        public SelectList ModelList { get; set; }
        public SelectList TypesList { get; set; }
        public async Task OnGetAsync()
        {
            await LoadSelectList();
            SetDate();
            CarRentInformation = await _carRentInformationService.GetAllNotCanceled();
        }

        public async Task<IActionResult> OnPost()
        {
            var list = await _carRentInformationService.SearchRecords(Manufacturer, Model, VehicleType, ClientId, FromDate, ToDate);
            SearchDone = list.Any();
            CarRentInformation = list.OrderBy(x => x.Id).ToList();
            await LoadSelectList();
            return Page();
        }

        private async Task LoadSelectList()
        {
            await LoadManufacturerList();
            await LoadModels(Manufacturer);
            await LoadVehicles();

        }

        private async Task LoadManufacturerList()
        {
            var manufacturerList = await _manufacturerService.GetAllWithModels();
            manufacturerList.Insert(0, new Core.Models.Manufacturer { Description = "Todos" });
            ManufacturerList = new SelectList(manufacturerList, nameof(Core.Models.Manufacturer.Id), nameof(Core.Models.Manufacturer.Description));

        }

        private async Task LoadModels(int id)
        {
            var models = await _modelService.GetModelByManufacturer(id);
            models.Insert(0, new Core.Models.Model { Description = "Todos" });
            ModelList = new SelectList(models, nameof(Core.Models.Model.Id), nameof(Core.Models.Model.Description));

        }

        private async Task LoadVehicles()
        {
            var stateList = await _vehicleTypeService.GetAll();
            stateList.Insert(0, new Core.Models.VehicleType() { Description = "Todos" });
            TypesList = new SelectList(stateList, nameof(Core.Models.VehicleType.Id), nameof(Core.Models.VehicleType.Description));

        }

        private void SetDate()
        {
            FromDate = DateTime.Today;
            ToDate = DateTime.Today;
        }
    }
}
