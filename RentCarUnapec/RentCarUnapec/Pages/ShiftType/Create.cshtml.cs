using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.ShiftType
{
    [Authorize]
    public class CreateModel : PageModel
    {

        public CreateModel(IShiftTypeService shiftTypeService)
        {
            _shiftTypeService = shiftTypeService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Core.Models.ShiftType ShiftType { get; set; }
        public IShiftTypeService _shiftTypeService { get; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _shiftTypeService.Create(ShiftType);

            return RedirectToPage("./Index");
        }
    }
}
