using System;
using System.Threading.Tasks;
using jsreport.AspNetCore;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Controllers
{
    public class ReportController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly ICarRentInformationService _carRentInformationService;
        private readonly IJsReportMVCService _jsReportMvcService;

        public ReportController(IVehicleService vehicleService,ICarRentInformationService carRentInformationService,IJsReportMVCService jsReportMvcService)
        {
            _vehicleService = vehicleService;
            _carRentInformationService = carRentInformationService;
            _jsReportMvcService = jsReportMvcService;
        }
        [MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> Index()
        {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);
            return View("ReportTest",await  _vehicleService.GetAll());
        }
        [MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> GetCarRentReport(int manufacturerId,int modelId,int typeId, int clientId,DateTime fromDate, DateTime toDate)
        {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);
            var list = await _carRentInformationService.SearchRecords(manufacturerId, modelId, typeId,clientId,fromDate,toDate);
            return View("CarRentReport",list);
        }
    }
}
