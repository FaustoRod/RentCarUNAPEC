using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.ShiftType
{
    [Authorize]
    public class DeleteModel : PageModel
    {

        public DeleteModel(IShiftTypeService shiftTypeService)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _shiftTypeService.Delete(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
