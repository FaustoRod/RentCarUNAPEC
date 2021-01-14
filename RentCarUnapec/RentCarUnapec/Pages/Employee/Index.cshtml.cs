using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.Employee
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IList<Core.Models.Employee> Employee { get;set; }
        public IEmployeeService _employeeService { get; }

        public async Task OnGetAsync()
        {
            Employee = await _employeeService.GetAll();
        }
    }
}
