using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Employee
{
    [Authorize]
    public class CreateModel : PageModel
    {

        public CreateModel(IEmployeeService employeeService,IShiftTypeService shiftTypeService)
        {
            _employeeService = employeeService;
            _shiftTypeService = shiftTypeService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ShiftTypeList = new SelectList(await _shiftTypeService.GetAll(), nameof(Core.Models.ShiftType.Id), nameof(Core.Models.ShiftType.Description));
            return Page();
        }

        [BindProperty]
        public Core.Models.Employee Employee { get; set; }
        public SelectList ShiftTypeList { get; set; }
        private IEmployeeService _employeeService { get; }
        private IShiftTypeService _shiftTypeService { get; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _employeeService.Create(Employee);

            return RedirectToPage("./Index");
        }
    }
}
