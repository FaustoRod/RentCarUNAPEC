using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Manufacturer
{
    [Authorize]
    public class EditModel : PageModel
    {

        public EditModel(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [BindProperty]
        public Core.Models.Manufacturer Manufacturer { get; set; }
        public IManufacturerService _manufacturerService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _manufacturerService.GetSingleById(id.Value);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _manufacturerService.Update(Manufacturer);

            return RedirectToPage("./Index");
        }

    }
}
