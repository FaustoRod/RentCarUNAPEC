using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.TransmissionType
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        public DeleteModel(ITransmissionTypeService transmissionTypeService)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _transmissionTypeService.Delete(id.Value);    

            return RedirectToPage("./Index");
        }
    }
}
