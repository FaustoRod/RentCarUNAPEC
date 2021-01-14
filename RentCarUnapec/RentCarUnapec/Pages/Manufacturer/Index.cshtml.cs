using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Manufacturer
{
    [Authorize]
    public class IndexModel : PageModel
    {
        
        public IndexModel(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        public IList<Core.Models.Manufacturer> Manufacturer { get;set; }
        public IManufacturerService _manufacturerService { get; }

        public async Task OnGetAsync()
        {
            Manufacturer = await _manufacturerService.GetAll();
        }
    }
}
