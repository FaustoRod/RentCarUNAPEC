using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Client
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IClientTypeService _clientTypeService;
        private readonly IIdentificationTypeService _identificationTypeService;

        public EditModel(IClientService clientService, IClientTypeService clientTypeService, IIdentificationTypeService identificationTypeService)
        {
            _clientTypeService = clientTypeService;
            _identificationTypeService = identificationTypeService;
            _clientTypeService = clientTypeService;
            _clientService = clientService;
        }

        [BindProperty]
        public Core.Models.Client Client { get; set; }
        public SelectList IdentificationTypeList { get; set; }
        public SelectList ClientTypeList { get; set; }
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
            await GetListItems();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await GetListItems();
                return Page();
            }

            await _clientService.Update(Client);

            return RedirectToPage("./Index");
        }
        private async Task GetListItems()
        {
            IdentificationTypeList = new SelectList(await _identificationTypeService.GetAll(), nameof(CommonModel.Id), nameof(CommonModel.Description));
            ClientTypeList = new SelectList(await _clientTypeService.GetAll(), nameof(CommonModel.Id), nameof(CommonModel.Description));
        }
    }
}
