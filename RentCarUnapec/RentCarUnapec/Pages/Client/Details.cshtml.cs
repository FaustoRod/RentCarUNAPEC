using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Client
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        public DetailsModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        public Core.Models.Client Client { get; set; }
        public IClientService _clientService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _clientService.GetSingleById(id.Value);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
