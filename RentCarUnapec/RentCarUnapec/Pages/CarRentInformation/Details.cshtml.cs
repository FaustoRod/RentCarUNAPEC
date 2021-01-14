using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.CarRentInformation
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ICarRentInformationService _carRentInformationService;

        public DetailsModel(ICarRentInformationService carRentInformationService)
        {
            _carRentInformationService = carRentInformationService;
        }

        public Core.Models.CarRentInformation CarRentInformation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarRentInformation = await _carRentInformationService.GetSingleById(id.Value);

            if (CarRentInformation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
