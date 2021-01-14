using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Client
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public IndexModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IList<Core.Models.Client> Client { get;set; }
        public IClientService _clientService { get; }

        public async Task OnGetAsync()
        {
            Client = await _clientService.GetAll();
        }
    }
}
