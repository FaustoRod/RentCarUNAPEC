using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Model
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public IndexModel(IModelService modelService)
        {
            _modelService = modelService;
        }

        public IList<Core.Models.Model> Model { get;set; }
        public IModelService _modelService { get; }

        public async Task OnGetAsync()
        {
            Model = await _modelService.GetAll();
        }
    }
}
