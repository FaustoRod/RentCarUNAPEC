using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Employee
{
    [Authorize]
    public class EditModel : PageModel
    {

        public EditModel(IEmployeeService employeeService,IShiftTypeService shiftTypeService)
        {
            _employeeService = employeeService;
            _shiftTypeService = shiftTypeService;
        }

        [BindProperty]
        public Core.Models.Employee Employee { get; set; }
        public SelectList ShiftTypeList { get; set; }

        public IEmployeeService _employeeService { get; }
        public IShiftTypeService _shiftTypeService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _employeeService.GetSingleById(id.Value);

            if (Employee == null)
            {
                return NotFound();
            }

            await GetShiftTypeListAsync();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await GetShiftTypeListAsync();
                return Page();
            }

            await _employeeService.Update(Employee);

            return RedirectToPage("./Index");
        }

        private async Task GetShiftTypeListAsync()
        {
            ShiftTypeList = new SelectList(await _shiftTypeService.GetAll(), nameof(Core.Models.ShiftType.Id), nameof(Core.Models.ShiftType.Description));

        }
    }
}
