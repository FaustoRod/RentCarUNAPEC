using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.FuelTankState
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public IndexModel(IFuelTankStateService fuelTankStateService)
        {
            _fuelTankStateService = fuelTankStateService;
        }

        public IList<Core.Models.FuelTankState> FuelTankState { get;set; }
        public IFuelTankStateService _fuelTankStateService { get; }

        public async Task OnGetAsync()
        {
            FuelTankState = await _fuelTankStateService.GetAll();
        }
    }
}
