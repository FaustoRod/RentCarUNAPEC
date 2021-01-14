using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;
using RentCarUnapec.Helpers;

namespace RentCarUnapec.Controllers
{
    public class RentReturnController : Controller
    {
        private readonly IRentReturnService _rentReturnService;

        public RentReturnController(IRentReturnService rentReturnService)
        {
            _rentReturnService = rentReturnService;
        }
        public async Task<IActionResult> Create(int id)
        {
            var result = await _rentReturnService.Create(new RentReturn
            {
                EmployeeId = UserInfo.Instance.EmployeeId,
                CarRentInformationId = id
            });

            return new JsonResult(result);
        }
    }
}
