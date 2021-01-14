using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Vehicle
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public IndexModel(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public IList<Core.Models.Vehicle> Vehicle { get;set; }
        public IVehicleService _vehicleService { get; }

        public async Task OnGetAsync()
        {
            Vehicle = await _vehicleService.GetAll();
        }
    }
}
