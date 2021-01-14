using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.TransmissionType
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public IndexModel(ITransmissionTypeService transmissionTypeService)
        {
            _transmissionTypeService = transmissionTypeService;
        }

        public IList<Core.Models.TransmissionType> TransmissionTypes { get;set; }
        public string ModelName { get; set; }
        public ITransmissionTypeService _transmissionTypeService { get; }

        public async Task OnGetAsync()
        {
            ModelName = "Tipo Transmision";
            TransmissionTypes = await _transmissionTypeService.GetAll();
        }
    }
}
