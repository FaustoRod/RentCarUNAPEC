using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<IActionResult> GetClients(string name, string identification)
        {
            var list = await _clientService.GetClientsByNameIdentification(name, identification);
            return PartialView("~/Pages/Client/_ClientSearchResultTable.cshtml",list);
        }

        [HttpGet]
        public IActionResult ValidateCedula(string cedula)
        {
            return new JsonResult(_clientService.ValidateCedula(cedula));
        }
    }
}
