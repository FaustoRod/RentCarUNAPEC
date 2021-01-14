using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentCarUnapec.Core.Dto;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapecApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentReturnController : ControllerBase
    {
        private readonly IRentReturnService _rentReturnService;

        public RentReturnController(IRentReturnService rentReturnService)
        {
            _rentReturnService = rentReturnService;
        }

        [HttpPost]
        [Route("ReturnVehicle")]
        public async Task<ActionResult> Create([FromBody]RentReturnDto rentReturn)
        {
            var result = await _rentReturnService.Create(new RentReturn
            {
                EmployeeId = rentReturn.EmployeeId,
                CarRentInformationId = rentReturn.RentId
            });

            return Ok(result);
        }
    }
}
