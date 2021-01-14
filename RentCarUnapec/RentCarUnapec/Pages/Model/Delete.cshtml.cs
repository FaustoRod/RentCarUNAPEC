using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Model
{
    [Authorize]
    public class DeleteModel : PageModel
    {

        public DeleteModel(IModelService modelService)
        {
            _modelService = modelService;
        }

        [BindProperty]
        public Core.Models.Model Model { get; set; }
        public IModelService _modelService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Model = await _modelService.GetSingleById(id.Value);

            if (Model == null)
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

            await _modelService.Delete(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
