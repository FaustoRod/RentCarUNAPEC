using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.VehicleType
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public IVehicleTypeService _vehicleTypeService { get; }

        public IndexModel(IVehicleTypeService vehicleService)
        {
            _vehicleTypeService = vehicleService;
        }

        public IList<Core.Models.VehicleType> VehicleType { get;set; }
        public string ModelName { get; set; }
        public async Task OnGetAsync()
        {
            ModelName = "Tipo de Vehiculos";
            VehicleType = await _vehicleTypeService.GetAll();
        }
    }
}
