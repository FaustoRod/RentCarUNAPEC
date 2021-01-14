using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.ShiftType
{
    [Authorize]
    public class EditModel : PageModel
    {

        public EditModel(IShiftTypeService shiftTypeService)
        {
            _shiftTypeService = shiftTypeService;
        }

        [BindProperty]
        public Core.Models.ShiftType ShiftType { get; set; }
        public IShiftTypeService _shiftTypeService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShiftType = await _shiftTypeService.GetSingleById(id.Value);

            if (ShiftType == null)
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

            await _shiftTypeService.Update(ShiftType);

            return RedirectToPage("./Index");
        }

    }
}
