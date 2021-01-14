using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.FuelType
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public IndexModel(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        public IList<Core.Models.FuelType> FuelType { get;set; }
        public IFuelTypeService _fuelTypeService { get; }

        public async Task OnGetAsync()
        {
            FuelType = await _fuelTypeService.GetAll();
        }
    }
}
