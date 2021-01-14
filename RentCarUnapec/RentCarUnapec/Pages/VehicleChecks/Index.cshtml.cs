using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.VehicleChecks
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IVehicleCheckService _vehicleCheckService;

        public IndexModel(IVehicleCheckService vehicleCheckService)
        {
            _vehicleCheckService = vehicleCheckService;
        }

        public IList<VehicleCheck> VehicleCheck { get;set; }

        public async Task OnGetAsync()
        {
            VehicleCheck = await _vehicleCheckService.GetAll();
        }
    }
}
