using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.TransmissionType
{
    [Authorize]
    public class EditModel : PageModel
    {

        public EditModel(ITransmissionTypeService transmissionTypeService)
        {
            _transmissionTypeService = transmissionTypeService;
        }

        [BindProperty]
        public Core.Models.TransmissionType TransmissionType { get; set; }
        public ITransmissionTypeService _transmissionTypeService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransmissionType = await _transmissionTypeService.GetSingleById(id.Value);

            if (TransmissionType == null)
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

            await _transmissionTypeService.Update(TransmissionType);

            return RedirectToPage("./Index");
        }

    }
}
