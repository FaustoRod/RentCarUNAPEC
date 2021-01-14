using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Employee
{
    [Authorize]
    public class DetailsModel : PageModel
    {

        public DetailsModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Core.Models.Employee Employee { get; set; }
        public IEmployeeService _employeeService { get; }

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
            return Page();
        }
    }
}
