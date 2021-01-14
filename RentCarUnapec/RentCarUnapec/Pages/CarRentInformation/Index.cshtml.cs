using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.CarRentInformation
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IModelService _modelService;
        private readonly IRentStateService _rentStateService;

        public IndexModel(ICarRentInformationService carRentInformationService,
            IManufacturerService manufacturerService,
            IModelService modelService,
            IRentStateService rentStateService)
        {
            _manufacturerService = manufacturerService;
            _modelService = modelService;
            _rentStateService = rentStateService;
            _carRentInformationService = carRentInformationService;
        }

        public IList<Core.Models.CarRentInformation> CarRentInformation { get; set; }
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
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public SelectList ManufacturerList { get; set; }
        public SelectList ModelList { get; set; }
        public SelectList StatesList { get; set; }
        public ICarRentInformationService _carRentInformationService { get; }

        public async Task OnGetAsync()
        {
            await LoadSelectList();
            CarRentInformation = await _carRentInformationService.GetAllNotCanceled();
        }


        public async Task OnPost()
        {
            CarRentInformation = await _carRentInformationService.SearchRecords(Manufacturer, Model, State);
            await LoadSelectList();
        }

        private async Task LoadSelectList()
        {
            await LoadManufacturerList();
            await LoadModels(Manufacturer);
            await LoadStates();

        }

        private async Task LoadManufacturerList()
        {
            var manufacturerList = await _manufacturerService.GetAllWithModels();
            manufacturerList.Insert(0, new Core.Models.Manufacturer { Description = "Todos" });
            ManufacturerList = new SelectList(manufacturerList, nameof(Core.Models.Manufacturer.Id), nameof(Core.Models.Manufacturer.Description));

        }

        private async Task LoadModels(int id)
        {
            //var models = await _modelService.GetAll();
            var models = await _modelService.GetModelByManufacturer(id);
            models.Insert(0, new Core.Models.Model { Description = "Todos" });
            ModelList = new SelectList(models, nameof(Core.Models.Model.Id), nameof(Core.Models.Model.Description));

        }

        private async Task LoadStates()
        {
            var stateList = await _rentStateService.GetAll();
            stateList.Insert(0, new Core.Models.RentState { Description = "Todos" });
            StatesList = new SelectList(stateList, nameof(Core.Models.RentState.Id), nameof(Core.Models.RentState.Description));

        }
    }
}
