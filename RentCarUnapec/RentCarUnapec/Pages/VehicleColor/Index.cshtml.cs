using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.VehicleColor
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public IndexModel(IVehicleColorService vehicleColorService)
        {
            _vehicleColorService = vehicleColorService;
        }

        public IList<Core.Models.VehicleColor> VehicleColor { get;set; }
        public string ModelName { get; set; }
        public IVehicleColorService _vehicleColorService { get; }

        public async Task OnGetAsync()
        {
            ModelName = "Color de Vehiculo";
            VehicleColor = await _vehicleColorService.GetAll();
        }
    }
}
