using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.ShiftType
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public IndexModel(IShiftTypeService shiftTypeService)
        {
            _shiftTypeService = shiftTypeService;
        }

        public IList<Core.Models.ShiftType> ShiftType { get;set; }
        public IShiftTypeService _shiftTypeService { get; }

        public async Task OnGetAsync()
        {
            ShiftType = await _shiftTypeService.GetAll();
        }
    }
}
