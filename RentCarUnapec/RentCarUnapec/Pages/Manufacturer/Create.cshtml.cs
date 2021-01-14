using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Manufacturer
{
    [Authorize]
    public class CreateModel : PageModel
    {

        public CreateModel(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Core.Models.Manufacturer Manufacturer { get; set; }
        public IManufacturerService _manufacturerService { get; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _manufacturerService.Create(Manufacturer);

            return RedirectToPage("./Index");
        }
    }
}
